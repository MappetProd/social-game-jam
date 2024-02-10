using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class TaskFollowPlayer : TaskGoToTarget
{
    private float _waitCounter = 0f;
    public TaskFollowPlayer(Transform transform, float distanceToStayAway, float speed) 
        : base(transform, distanceToStayAway, speed) { }

    public override NodeState Evaluate()
    {
        base.Evaluate();
        if (_waitCounter > EnemyBT.waitTimeTillChaseInSeconds)
        {
            _waitCounter = 0f;
            parent.parent.SetData("canChase", true);
            return NodeState.SUCCESS;
        }

        _waitCounter += Time.deltaTime;

        return NodeState.RUNNING;
    }

}
