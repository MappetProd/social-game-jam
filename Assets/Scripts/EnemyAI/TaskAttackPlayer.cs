using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class TaskAttackPlayer : Node
{
    private Transform _lastTarget;
    // player manager

    public TaskAttackPlayer(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData(EnemyBT.targetKey);
        if (target != _lastTarget)
        {
            // todo playermanager
            _lastTarget = target;
        }

        ClearData(EnemyBT.targetKey);
        state = NodeState.RUNNING;
        return state;

    }

}
