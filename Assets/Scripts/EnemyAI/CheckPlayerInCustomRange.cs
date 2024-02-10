using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class CheckPlayerInCustomRange : Node
{
    private Transform _transform;
    private float _customRange;
    private static int _playerLayerMask = 1 << 6;

    public CheckPlayerInCustomRange(Transform transform, float range)
    {
        _transform = transform;
        _customRange = range;
    }

    public override NodeState Evaluate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, _customRange, _playerLayerMask);
        if (colliders.Length > 0)
        {
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
