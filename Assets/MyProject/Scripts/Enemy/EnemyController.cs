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
    public float movementSpeed;

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

        this.movementSpeed = speed;
    }

    //Damage
    public void EnemyTakeDam(int amount)
    {
        EnemyModel.Health -= amount;
        if(EnemyModel.Health <= 0)
        {
            Debug.Log("Enemy has died");
        }
        else
        {
            Debug.Log("Enemy took damage of: " + amount);
            Debug.Log("Updated Health of enemy: " + EnemyModel.Health);
        }
    }

 
}
