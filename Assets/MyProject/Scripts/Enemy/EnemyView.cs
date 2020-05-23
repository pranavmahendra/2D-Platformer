using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public int speed;

    public Animator animator;
    public EnemyController enemyController;

    
    [SerializeField]
    private EnemyState currentState;

    [SerializeField]
    public EnemyIdleState EnemyIdleState;
    [SerializeField]
    public EnemyStop enemyStop;
    [SerializeField]
    public EnemyAttack enemyAttack;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 1;

       

        ChangeState(EnemyIdleState);
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyController.Movement();
    }

    public void Initialize(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Triggers"))
        {
            if (speed == 1)
            {
                speed = -1;
            }
            else if (speed == -1)
            {
                speed = 1;
            }
        }
   
    }

    //State Machine logic.
    public void ChangeState(EnemyState newState)
    {
        if (currentState != null)
        {
            currentState.onExitState();
        }
        currentState = newState;
        currentState.onEnterState();
    }

}
