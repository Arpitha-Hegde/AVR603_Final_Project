using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Patrol: FSMState
{
    public override void StateUpdate(Transform[] waypoints, ref int wpIndex, Transform player, Transform npc)
    {
        Vector3 target = waypoints[wpIndex].position; // identify next waypoint
        npc.Translate((target - npc.position). normalized * EnemyAI.speed * Time.deltaTime); // move towards waypoint

        if(Vector3.Distance(target, npc.position) < 2f)
            wpIndex = (wpIndex + 1) % waypoints.Length;
    }

    public override State CheckTransitionRules(Transform player, Transform npc, int health)
    {
        if (Vector3.Distance(npc.position, player.position) < 8f)
            return State.chase;
        return State.patrol;
    }
}
