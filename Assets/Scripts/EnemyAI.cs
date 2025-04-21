using System.Collections.Generic;
using UnityEngine;

public enum State
{
    patrol,
    chase,
    attack,
    dead
};
public class EnemyAI : MonoBehaviour
{
    public int health = 100;
    public static float speed = 5f;
    Transform player;
    public Transform[] waypoints;
    int wpIndex;

    public State currentState;

    Dictionary<State, FSMState> stateDict = new Dictionary<State, FSMState>
    {
        {State.patrol,  new Patrol() },
        {State.chase,   new Chase() }
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = State.patrol;
        wpIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        FSMState state = stateDict[currentState];
        state.StateUpdate(waypoints, ref wpIndex, player, transform);
        currentState = state.CheckTransitionRules(player, transform, health);
    }

    void OnTriggerEnter(Collider other)
    {
        if (currentState == State.chase && other.CompareTag("Player"))
        {
            Collider myCol = GetComponent<Collider>();
            Collider otherCol = other.GetComponent<Collider>();

            if (myCol != null && otherCol != null)
            {
                Vector3 direction;
                float penetrationDepth;

                bool areIntersecting = Physics.ComputePenetration(
                    myCol, transform.position, transform.rotation,
                    otherCol, other.transform.position, other.transform.rotation,
                    out direction, out penetrationDepth
                );

                if (areIntersecting && penetrationDepth > 0.25f) // <<– adjustable threshold
                {
                    Debug.Log($"Full body collision! areIntersecting: {areIntersecting} Penetration depth: {penetrationDepth}");
                    QuestManager.Instance?.EndGame(false);
                }
                else
                {
                    Debug.Log($"Too shallow. areIntersecting: {areIntersecting} Penetration depth: {penetrationDepth}");
                }
            }
        }
    }
}
