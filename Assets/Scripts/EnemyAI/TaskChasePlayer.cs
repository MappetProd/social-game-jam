using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChasePlayer : TaskGoToTarget
{
    public TaskChasePlayer(Transform transform, float distanceToStayAway, float speed) 
        : base(transform, distanceToStayAway, speed) { }
    public override NodeState Evaluate()
    {
        return base.Evaluate();
    }
}
