using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform playerHead;

    private void Update()
    {
        transform.position = playerHead.transform.position;
    }
}