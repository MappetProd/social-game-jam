using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using System;

public class TaskGoToTarget : Node
{
    protected Transform _transform;
    protected float _socialDistance;
    protected float _speed;

    public TaskGoToTarget(Transform transform, float distanceToStayAway, float speed)
    {
        _transform = transform;
        _socialDistance = distanceToStayAway;
        _speed = speed;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData(EnemyBT.targetKey);
        if (target == null)
        {
            Debug.LogError("target is null!");
            state = NodeState.FAILURE;
            return state;
        }
        
        if (Vector2.Distance(_transform.position, target.position) > _socialDistance)
        {
            // TODO ANIMATION
            _transform.position = Vector2.MoveTowards(_transform.position, target.position, _speed * Time.deltaTime);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
