using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public BulletController bulletController;
    public Rigidbody2D rb2d;


  
    public void Initialize(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        bulletController.BulletMovement();
        //bulletController.DestroyLogic();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyChildTrigger>())
        {
            Destroy(gameObject);
        }
        else
        {
            bulletController.DestroyLogic();
        }
    }
}
