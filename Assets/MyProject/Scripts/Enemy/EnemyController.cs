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

    //Movement
    public void Movement()
    {
        float speed = enemyView.speed;
        enemyView.animator.SetBool("isWalking", isWalking());

        Vector3 scale = enemyView.transform.localScale;

        if (speed < 0)
        {
           scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        enemyView.transform.localScale = scale;
        enemyView.transform.Translate(Vector3.right * enemyView.speed * Time.deltaTime);

    }




}
