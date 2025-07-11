using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemymanager : MonoBehaviour
{
    public int health = 100;
    private AudioSource audioSource;
    private ParticleSystem particleSystem;
    private Animator animator;
    private NavMeshAgent agent;

    private bool isSinking = false;
    public bool isDead = false;
    public AudioClip deathSound;
    public void hit(RaycastHit shootHit)
    {
        if (isDead) return;
        health -= 10;
        audioSource.Play();
        particleSystem.transform.position = shootHit.point;
        particleSystem.Play();

        if (health <= 0)
        {
            Death();
        }

    }

    private void Death()
    {
        isDead = true;
        animator.SetTrigger("Death");
        audioSource.clip = deathSound;
        audioSource.Play();
        agent.enabled = false;
        
    }

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSinking)
        {transform.Translate(-transform.up * 2.5f * Time.deltaTime);}
    }

    public void StartSinking()
    {
        isSinking = true;
        
        Destroy(gameObject, 2f);
    }
}
