using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChildTrigger : MonoBehaviour
{
    public EnemyView enemyView;

    //Enemy hurt functions are mentioned here.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>())
        {
            enemyView.animator.SetBool("isHurt", true);

        }

        else if (collision.gameObject.GetComponent<BulletView>())
        {
            //Take damage function of enemy.
            enemyView.animator.SetTrigger("isShot");

            //Play audio when bullet hits enemy.
            EnemyService.Instance.audioService.audioSources[0].clip = EnemyService.Instance.audioService.enemyAudioClips[4];
            EnemyService.Instance.audioService.audioSources[0].Play();
            EnemyService.Instance.audioService.audioSources[0].loop = false;

            enemyView.speed = 0;

            //VFX for bullet explosion.
            VFXService.Instance.CreateBulletExplosion(enemyView.transform.position, enemyView.transform.rotation);
            enemyView.enemyController.EnemyTakeDam(BulletService.Instance.bulletController.BulletModel.Damage);
            StartCoroutine(ResetValues());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerView>())
        {
            enemyView.animator.SetBool("isHurt", false);
        }
    }

    private IEnumerator ResetValues()
    {
        yield return new WaitForSeconds(0.5f); //invul time
        enemyView.speed = 1;
        enemyView.animator.SetTrigger("isShot"); //play hit trigger
    }
}
