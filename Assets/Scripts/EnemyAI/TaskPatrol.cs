using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus;
using BehaviorTree;
using UnityEngine.AI;

public class TaskPatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;

    private NavMeshAgent _agent;

    private int _currentWaypointIndex = 0;

    private float _waitTimeInSeconds = 1f;
    private float _waitCounter = 0f;
    private bool _isWaiting = false;

    public TaskPatrol(Transform transform, Transform[] waypoints) 
    {
        _transform = transform;
        _waypoints = waypoints;
        _agent = transform.GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public override NodeState Evaluate()
    {
        if (_isWaiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTimeInSeconds)
            {
                _isWaiting = false;
                _waitCounter = 0f;
            }
        }
        else
        {
            Transform currentWaypoint = _waypoints[_currentWaypointIndex];
            if (Vector2.Distance(_transform.position, currentWaypoint.position) < 0.01f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _transform.position = currentWaypoint.position;
                _isWaiting = true;
            }
            else
            {
                //TODO: ANIMATIONS
                //_transform.position = Vector3.MoveTowards(_transform.position, currentWaypoint.position, EnemyBT.followSpeed * Time.deltaTime);
                _agent.speed = EnemyBT.patrolSpeed;
                _agent.SetDestination(currentWaypoint.position);
            }
        }

        state = NodeState.RUNNING;
        return state;

    }
}
