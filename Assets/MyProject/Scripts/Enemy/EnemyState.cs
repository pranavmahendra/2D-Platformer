using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public EnemyView enemyView;

    private void Start()
    {
        enemyView = EnemyService.Instance.enemyController.enemyView;
    }


    public virtual void onEnterState()
    {
        this.enabled = true;
    }

    public virtual void onExitState()
    {
        this.enabled = false;
    }


}
