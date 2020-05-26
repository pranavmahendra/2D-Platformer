using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChildTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>())
        {
            EnemyService.Instance.enemyController.enemyView.animator.SetBool("isHurt", true);

            //Take damage function of enemy.
             EnemyService.Instance.enemyController.EnemyTakeDam(30);
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>())
        {
            EnemyService.Instance.enemyController.enemyView.animator.SetBool("isHurt", false);
        }
    }

}
