using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyService : Monosingleton<EnemyService>
    {
        private EnemyModel enemyModel;
        public EnemyView enemyView;
        public EnemyController enemyController;


        public AudioService audioService;
        //all events for death, attack, idle will be here.
        //they will be used for audio.
        //public event Action EnemyDied;

        //public List<EnemyController> enemyList = new List<EnemyController>();

        private void Start()
        {
            CreateEnemy();

            PlayAudio();

            //AudioService.Instance.InitializeEnemy(this.enemyController.enemyView);
            //enemyController.enemyView.enemyAttack.isAttacking += startedAttacking;
        }

        private void startedAttacking()
        {
            //PLayEffect();
        }

        public EnemyController CreateEnemy()
        {
            enemyModel = new EnemyModel(100, 20);
            EnemyController enemyController = new EnemyController(enemyModel, enemyView);

            //Add enemy to list
            this.enemyController = enemyController;
            //Debug.Log("Size of list is " + enemyList.Count);

            return enemyController;
        }

        //Play Audio effects.
        public void PlayAudio()
        {

            audioService.audioSources[0].clip = audioService.enemyAudioClips[0];
            audioService.audioSources[0].Play();
            audioService.audioSources[0].loop = true;

        }


        //public void InvokeEnemyDead()
        //{
        //    EnemyDied?.Invoke();
        //}

        //public void PLayEffect()
        //{
        //    VFXService.Instance.CreatePoison(enemyController.enemyView.transform.position, enemyController.enemyView.transform.rotation);
        //}
    }
}

