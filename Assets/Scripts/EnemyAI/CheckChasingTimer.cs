using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class CheckChasingTimer : Node
{
    private Transform _transform;
    private static int _playerLayerMask = 1 << 6;
    public CheckChasingTimer(Transform transform) 
    {
        _transform = transform;
    }
    public override NodeState Evaluate()
    {
        object result = GetData("canChase");
        if (result != null && (bool)result == true)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, EnemyBT.followingRange, _playerLayerMask);
            if (colliders.Length == 0)
            {
                ClearData("canChase");
                state = NodeState.FAILURE;
                return state;
            }

            state = NodeState.SUCCESS;
        }
        else
        {
            state = NodeState.FAILURE;
        }

        return state;
    }
}
