using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float Lifetime;
    public Rigidbody2D rb;

    public int damage;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        DestroyProjectile();
    }


    void DestroyProjectile()
    {
        Destroy(gameObject, Lifetime);
    }

    void DestroyOnCollision()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerView>())
        {
            //collision.GetComponent<PlayerView>().playerController.TakeDamage(damage);
        
            DestroyOnCollision();
        }
    }


}
