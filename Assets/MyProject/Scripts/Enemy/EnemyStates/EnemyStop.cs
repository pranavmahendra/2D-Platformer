using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : EnemyState
{
    private Transform PlayerPos;

    public override void onEnterState()
    {
        base.onEnterState();
        enemyView.speed = 0;
        //Debug.Log("Enemy has stopped!!!");
    }

    public override void onExitState()
    {
        base.onExitState();
        enemyView.speed = 1;
    }

    private void Update()
    {
        //enemyView.CheckToFire();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
            
            enemyView.ChangeState(enemyView.enemyStop);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>() != null)
        {
            enemyView.ChangeState(enemyView.EnemyIdleState);
        }
    }

}
