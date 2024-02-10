using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class TaskAttackPlayer : Node
{
    private Transform _lastTarget;
    private Health _targetHealth;

    public TaskAttackPlayer(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData(EnemyBT.targetKey);
        if (target != _lastTarget)
        {
            _targetHealth = target.GetComponent<Health>();
            _lastTarget = target;
        }

        // todo animations
        _targetHealth.TakeHit(100);
        if (_targetHealth.isDead)
        {
            ClearData(EnemyBT.targetKey);
        }

        state = NodeState.RUNNING;
        return state;

    }

}
