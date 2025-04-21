using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chase : FSMState
{
    public override void StateUpdate(Transform[] waypoints, ref int wpIndex, Transform player, Transform npc)
    {
        Vector3 target = player.position; // target is the player
        npc.Translate((target - npc.position).normalized * EnemyAI.speed * Time.deltaTime); // move towards waypoint
    }

    public override State CheckTransitionRules(Transform player, Transform npc, int health)
    {
        if (Vector3.Distance(npc.position, player.position) > 10f)
            return State.patrol;
        return State.chase;
    }
}
