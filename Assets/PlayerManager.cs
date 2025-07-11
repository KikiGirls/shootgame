using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum states
    {
        idle = 0,
        walk = 1,
        death = 2,
    }
    public states state;
    public Animator animator;
    
    public int health = 100;
    

    void Awake()
    {
        state = states.idle;
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("state", (int)state);
    }
}
