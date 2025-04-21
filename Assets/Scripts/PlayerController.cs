using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public int walkSpeed;

    [HideInInspector]
    public Vector3 InputDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        GetComponent<CharacterController>().Move(InputDirection * walkSpeed * Time.deltaTime);

        //if (QuestManager.Instance != null && (QuestManager.Instance.QuestCompleted || QuestManager.Instance.QuestFailed))
        //    return; // skip movement update
    }
}
