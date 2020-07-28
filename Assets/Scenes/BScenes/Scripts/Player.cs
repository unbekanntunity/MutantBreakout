using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Com.Kawaiisun.SimpleHostile
{
    public class Player : MonoBehaviour
    {

        #region Variables

        [Header("Requiered")]
        public Camera normalCam;
        public GameObject player;
        public GameObject cameraParent;
     
        public Transform groundDetector;
        public LayerMask ground;
        public GameObject standingCollider;
        public GameObject crouchingCollider;
        public GameObject mesh;
        public TextMeshPro playerUsername;

        [Header("Controls")]
        [SerializeField]
        private KeyCode SprintKey_Prim;
        [SerializeField]
        private KeyCode SprintKey_Sec;

        [SerializeField]
        private KeyCode JumpKey_Prim;
        [SerializeField]
        private KeyCode JumpKey_Sec;

        [SerializeField]
        private KeyCode CrouchKey_Prim;
        [SerializeField]
        private KeyCode CrouchKey_Sec;

        [SerializeField]
        private int AimKey_Prim;

        [Header("Settings")]
        public float speed;
        public float sprintModifier;
        public float crouchModifier;
        public float slideModifier;
        public float jumpForce;

        public float crouchAmount;
        private Rigidbody rig;

        private float baseFOV;
        private float sprintFOVModifier = 1.2f;
        private Vector3 origin;

        private bool crouched;

        private Vector3 normalCamTarget;
        private Vector3 weaponCamTarget;
        #endregion
  

        #region MonoBehaviour Callbacks

        private void Start()
        {
         
            baseFOV = normalCam.fieldOfView;
            origin = normalCam.transform.localPosition;

            rig = GetComponent<Rigidbody>();
          
        }

     
        private void Update()
            {
            //Axles
            float t_hmove = Input.GetAxisRaw("Horizontal");
            float t_vmove = Input.GetAxisRaw("Vertical");

            //Controls
            bool jump = Input.GetKeyDown(JumpKey_Prim) || Input.GetKey(JumpKey_Sec);

            //States
            bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.15f, ground);
            bool isJumping = jump && isGrounded;

            //Jumping
            if (isJumping)
            {
                rig.AddForce(Vector3.up * jumpForce);
            }

        }

        void FixedUpdate()
        {
           
            //Axles
            float t_hmove = Input.GetAxisRaw("Horizontal");
            float t_vmove = Input.GetAxisRaw("Vertical");


            //Controls
            bool sprint = Input.GetKey(SprintKey_Prim) || Input.GetKey(SprintKey_Sec);
            bool jump = Input.GetKeyDown(JumpKey_Prim) || Input.GetKey(JumpKey_Sec);

            //States
            bool isGrounded = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
            bool isJumping = jump && isGrounded;
            bool isSprinting = sprint && t_vmove > 0 && !isJumping && isGrounded;

            //Movement
            Vector3 t_direction = Vector3.zero;
            float t_adjustedSpeed = speed;

            t_direction = new Vector3(t_hmove, 0, t_vmove);
            t_direction.Normalize();
            t_direction = transform.TransformDirection(t_direction);

            if (isSprinting)
                {
                  
                    t_adjustedSpeed *= sprintModifier;
                }
                else if (crouched)
                {
                    t_adjustedSpeed *= crouchModifier;
                }
            
          

            Vector3 t_targetVelocity = t_direction * t_adjustedSpeed * Time.deltaTime;
            t_targetVelocity.y = rig.velocity.y;
            rig.velocity = t_targetVelocity;
        
            //Camera Stuff
           
           
            if (isSprinting)
                {
                    normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f);
                }
                else
                {
                    normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
                }

                if (crouched)
                {
                    normalCamTarget = Vector3.MoveTowards(normalCam.transform.localPosition, origin + Vector3.down * crouchAmount, Time.deltaTime);
                }
                else
                {
                    normalCamTarget = Vector3.MoveTowards(normalCam.transform.localPosition, origin, Time.deltaTime);
                }
           
        }
        private void LateUpdate()
        {
            normalCam.transform.localPosition = normalCamTarget;
        }

        #endregion

        #region Private Method
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "dangerous")
            {
                Destroy(player);
            }
        }

        #endregion
    }
}
