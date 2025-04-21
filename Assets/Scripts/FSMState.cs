using UnityEngine;

public abstract class FSMState : MonoBehaviour
{
    public abstract void StateUpdate(Transform[] waypoints, ref int wpIndex, Transform player, Transform npc);
    public abstract State CheckTransitionRules(Transform player, Transform npc, int health);
}
