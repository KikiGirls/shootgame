using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private GameObject player;

    private NavMeshAgent agent;
    
    private Enemymanager enemymanager;
    private void Awake()
    {
        enemymanager = GetComponent<Enemymanager>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemymanager.isDead)return;
        agent.SetDestination(player.transform.position);
    }
}
