using UnityEngine;
using UnityEngine.EventSystems;

public class NPCAnimator : MonoBehaviour
{
    Animator animator;
    public float turnSpeed;
    Transform parent;
    Vector3 curPosition, prevPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        parent = GetComponentInParent<Transform>();
        curPosition = parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        curPosition = new Vector3(parent.position.x, parent.position.y, parent.position.z);
        Vector3 moveDirection = curPosition - prevPosition;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection, Vector3.up), turnSpeed * Time.deltaTime);
        prevPosition = new Vector3(parent.position.x, parent.position.y, parent.position.z);
    }
}
