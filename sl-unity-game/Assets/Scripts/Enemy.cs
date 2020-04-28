﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : LivingEntity
{
    // Variables
    NavMeshAgent pathfinder;
    Transform target;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // UpdatePath is called at a slower interval to improve performance
    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;
        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
