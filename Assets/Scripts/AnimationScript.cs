using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    public Animator animator;

    public float Vertical_f;
    public float Horizontal_f;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    public float dampTime;

    void Update()
    {
        Vertical_f = Input.GetAxisRaw("Vertical");
        Horizontal_f = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Vertical_f", Vertical_f, 0.1f, Time.deltaTime);
        animator.SetFloat("Horizontal_f", Horizontal_f, 0.1f, Time.deltaTime);
    }
}
