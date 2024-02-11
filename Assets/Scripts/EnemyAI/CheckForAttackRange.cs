using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class CheckForAttacakRange : Node
{
    private Transform _transform;
    private static int _enemyLayerMask = 1 << 6;

    public CheckForAttacakRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, EnemyBT.attackingRange, _enemyLayerMask);
        if (colliders.Length > 0)
        {
            parent.parent.SetData(EnemyBT.targetKey, colliders[0].transform);
            parent.parent.SetData(EnemyBT.targetKey, colliders[0].transform);
            state = NodeState.SUCCESS;
        }
        else
        {
            state = NodeState.FAILURE;
        }

        return state;
    }
}
