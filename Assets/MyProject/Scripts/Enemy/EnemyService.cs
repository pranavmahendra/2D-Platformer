using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : Monosingleton<EnemyService>
{
    private EnemyModel enemyModel;
    public EnemyView enemyView;
    public EnemyController enemyController;

    //public List<EnemyController> enemyList = new List<EnemyController>();

    private void Start()
    {
        CreateEnemy();
        //enemyController.enemyView.enemyAttack.isAttacking += startedAttacking;
    }

    private void startedAttacking()
    {
        //PLayEffect();
    }

    public EnemyController CreateEnemy()
    {
        enemyModel = new EnemyModel(100);
        EnemyController enemyController = new EnemyController(enemyModel, enemyView);

        //Add enemy to list
        this.enemyController = enemyController;
        //Debug.Log("Size of list is " + enemyList.Count);

        return enemyController;
    }

    //public void PLayEffect()
    //{
    //    VFXService.Instance.CreatePoison(enemyController.enemyView.transform.position, enemyController.enemyView.transform.rotation);
    //}
}
