using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttack : EnemyState
{
    private bool enemyAttack;
    public event Action isAttacking;

    public override void onEnterState()
    {

        base.onEnterState();
        enemyView.speed = 0;
        enemyAttack = true;
        //send attack event
        isAttacking?.Invoke();

        enemyView.animator.SetBool("isAttacking", enemyAttack);
        Debug.Log("Enemy has started attacking");

    }

    public override void onExitState()
    {

        base.onExitState();
        enemyAttack = false;
        enemyView.animator.SetBool("isAttacking", enemyAttack);
        Debug.Log("Enemy has stopped attacking");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            enemyView.ChangeState(enemyView.enemyAttack);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>() != null)
        {
            enemyView.ChangeState(enemyView.enemyStop);
        }
    }

}
