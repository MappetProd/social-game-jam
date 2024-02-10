using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

public class EnemyBT : BehaviorTree.Tree
{
    public Transform[] waypoints;

    public static float patrolSpeed = 2f;
    public static float followSpeed = 2f;
    public static float chaseSpeed = 5f;

    public static float attackCooldownInSeconds;
    public static float waitTimeTillChaseInSeconds = 5f;

    public static float attackingRange = 1f;
    public static float followingRange = 30f;
    public static float chasingRange = 10f;

    public float chasingDistance = 0.01f;
    public float followingDistance = 20f;

    public static string targetKey = "current_target";


    protected override Node SetupTree()
    {
        Console.WriteLine("lmao");
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckForAttacakRange(transform),
                new TaskAttackPlayer(transform)
            }),

            new Sequence(new List<Node>
            {
                new Selector(new List<Node>
                {
                    new CheckChasingTimer(transform),
                    new CheckPlayerInCustomRange(transform, chasingRange),
                }),

                new TaskChasePlayer(transform, chasingDistance, chaseSpeed)
            }),

            new Sequence(new List<Node>
            {
                new CheckPlayerInCustomRange(transform, followingRange),
                new TaskFollowPlayer(transform, followingDistance, followSpeed)
            }),

            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
