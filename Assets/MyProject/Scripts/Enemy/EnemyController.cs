using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public EnemyController(EnemyModel enemyModel,EnemyView enemyPrefab)
    {
        EnemyModel = enemyModel;
        enemyPrefab = GameObject.Instantiate<EnemyView>(enemyPrefab);
        this.enemyView = enemyPrefab;
        enemyView.Initialize(this);

    }

    public EnemyModel EnemyModel { get; }
    public EnemyView enemyView { get; }


    private bool m_FacingRight = true;
   
    //is walking true or false
    private bool isWalking()
    {
        if(enemyView.speed == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //Is Dead true or false
    private bool isDead()
    {
        if (EnemyModel.Health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Movement
    public void Movement()
    {
        float speed = enemyView.speed;

        enemyView.animator.SetBool("isWalking", isWalking());
       
        if (speed > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (speed < 0 && m_FacingRight)
        {
            Flip();
        }

        void Flip()
        {
            m_FacingRight = !m_FacingRight;

            enemyView.transform.Rotate(0f, 180f, 0f);
        }

        if (!m_FacingRight)
        {
            enemyView.transform.Translate(speed * -1f * Time.deltaTime, 0f, 0f);
        }
        else
        {
            enemyView.transform.Translate(speed * 1f * Time.deltaTime, 0f, 0f);
        }

    }

    //Damage
    public void EnemyTakeDam(int amount)
    {
        EnemyModel.Health -= amount;
        if(EnemyModel.Health <= 0)
        {
            DestoryEnemey();
            enemyView.animator.SetBool("isDead", isDead());

            //EnemyService.Instance.InvokeEnemyDead();
        }
        else
        {
            enemyView.animator.SetBool("isDead", isDead());
            Debug.Log("Enemy took damage of: " + amount);
            Debug.Log("Updated Health of enemy: " + EnemyModel.Health);
        }
    }

    public void DestoryEnemey()
    {
        if(EnemyModel.Health <= 0)
        {
            Debug.Log("BAMM!!! Enemy Died");
            EnemyService.Instance.audioService.audioSources[0].clip = EnemyService.Instance.audioService.enemyAudioClips[3];
            EnemyService.Instance.audioService.audioSources[0].Play();
            EnemyService.Instance.audioService.audioSources[0].loop = false;
            EnemyView.Destroy(enemyView.gameObject, 0.5f);
        }
    }

 
}
