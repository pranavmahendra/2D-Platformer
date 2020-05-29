using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public int speed;

    public Animator animator;
    public EnemyController enemyController;

    public GameObject projectile;

    public Transform Tip;
    //private float rayDistance = 100f;


    [SerializeField]
    public EnemyState currentState;

    [SerializeField]
    public EnemyIdleState EnemyIdleState;
    [SerializeField]
    public EnemyStop enemyStop;
    [SerializeField]
    public EnemyAttack enemyAttack;

    private float fireRate;
    private float nextFire;


    // Start is called before the first frame update
    void Start()
    {
     
        animator = GetComponent<Animator>();

        speed = 1;

        fireRate = 2f;
        nextFire = Time.time;

        ChangeState(EnemyIdleState);
    }

    // Update is called once per frame
    void Update()
    {

        enemyController.Movement();

        CheckToFire();



    }

    //Initialize Enemy View
    public void Initialize(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    // On Trigger
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


    //Fire
    public void CheckToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, Tip.transform.position, Tip.transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }



}
