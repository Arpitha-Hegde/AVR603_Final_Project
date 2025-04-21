using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    public float turnSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = GetComponentInParent<PlayerController>().InputDirection;
        if (moveDirection == Vector3.zero)
            animator.SetInteger("State", 0); // transition to idle
        else
        {
            animator.SetInteger("State", 2); // trasition to run
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection, Vector3.up), turnSpeed * Time.deltaTime);
        }
    }
}
