using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttack : EnemyState
{
    private bool enemyAttack;
    private Transform PlayerPos;
    public event Action isAttacking;

    public override void onEnterState()
    {

        base.onEnterState();
        enemyView.speed = 0;
        enemyAttack = true;
        ////send attack event
        isAttacking?.Invoke();

        enemyView.animator.SetBool("isAttacking", enemyAttack);

        //PLay Attack Audio
        EnemyService.Instance.audioService.audioSources[0].clip = EnemyService.Instance.audioService.enemyAudioClips[2];
        EnemyService.Instance.audioService.audioSources[0].Play();
        EnemyService.Instance.audioService.audioSources[0].loop = false;

        //Debug.Log("Enemy has started attacking");

    }

    public override void onExitState()
    {

        base.onExitState();
        enemyAttack = false;
        enemyView.animator.SetBool("isAttacking", enemyAttack);
        //Debug.Log("Enemy has stopped attacking");

        EnemyService.Instance.PlayAudio();
    }

    private void Update()
    {
        //enemyView.transform.LookAt(PlayerPos.position);
        //enemyView.CheckToFire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>() != null)
        {
        //    GameObject player = collision.gameObject;
        //    Transform goal = new Vector2(player.transform.posi)
        //    this.PlayerPos = goal;
    
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
