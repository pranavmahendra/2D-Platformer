﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        public PlayerController playerController;

        [HideInInspector]
        public Animator animator;
        [HideInInspector]
        public Rigidbody2D rb2d;
        [HideInInspector]
        public CapsuleCollider2D capsule;



        public float jumpForce;
        public int speed;

        private float health;

        public Transform tipPosition;
        public GameObject projectile;

        public AudioSource audioSource;
        public List<AudioClip> audioClips;

        public ParticleSystem dustPuff;

        [HideInInspector]
        public bool isGrounded = true;

        [HideInInspector]
        public bool alreadyPlayed = true;


        private void Start()
        {
            animator = GetComponent<Animator>();
            rb2d = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
            capsule = GetComponent<CapsuleCollider2D>();

            VFXService.Instance.CreateRespawn(this.transform.position, this.transform.rotation);

        }

        public float getHealh()
        {
            health = playerController.PlayerModel.health;
            return health;
        }

        public void Initialize(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        private void Update()
        {

            playerController.playerJump();
            playerController.PlayerCrouch();
            playerController.PlayerAttack();
            //playerController.PlayerHurt();
        }

        private void LateUpdate()
        {
            playerController.playerRun();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                playerController.PlayerPush(true);
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
            {
                isGrounded = true;

                dustPuff.Play();

                playerController.isJumping = false;

                if (isGrounded)
                {
                    if (playerController.isMoving())
                    {
                        PlayerService.Instance.audioService.audioSources[1].clip = PlayerService.Instance.audioService.playerAudioClips[0];
                        PlayerService.Instance.audioService.audioSources[1].Play();
                        PlayerService.Instance.audioService.audioSources[1].loop = true;
                    }
                    else if (playerController.isMoving() == false)
                    {
                        PlayerService.Instance.InvokeLand();
                    }

                }

            }
            else if (collision.gameObject.GetComponent<PressurePad>())
            {
                playerController.isJumping = false;
                isGrounded = true;
            }

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                playerController.PlayerPush(false);
            }

            else if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
            {
                isGrounded = false;
                alreadyPlayed = false;
                dustPuff.Stop();
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //Hurt animation play.
            if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyTriggerAttack"))
            {
                animator.SetBool("Hurt", true);
                playerController.isHurt = true;
            }
            //If collided with Enemy Bullet.
            else if (collision.gameObject.layer == LayerMask.NameToLayer("BossBullet"))
            {
                playerController.TakeDamage(EnemyService.Instance.enemyController.EnemyModel.Damage);
                //For UI hearts.
                playerController.CheckHealth();

                if (playerController.PlayerModel.health > 0)
                {
                    StartCoroutine(SetHurtFalse());
                }
            }

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyTriggerAttack"))
            {
                playerController.isHurt = false;
                animator.SetBool("Hurt", false);
            }
        }


        IEnumerator SetHurtFalse()
        {
            playerController.isHurt = false;
            yield return new WaitForSeconds(0.2f);
            animator.SetBool("Hurt", false);
        }
    }

}
