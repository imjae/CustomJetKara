using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 8f;
    public int Damage = 10;

    private Rigidbody2D bulletRigidbody;
    private Collider2D bulletCollider;
    private Animator animator;

    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = Vector2.right * speed;
        Destroy(gameObject, 3f);

        bulletCollider = gameObject.GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.tag.Equals("Player"))
        {
            if (collision.tag.Equals("Enemy"))
            {
                bulletRigidbody.velocity = Vector2.zero;
                animator.SetTrigger("Explosion");
            }
        }
    }

    void BulletExplosion()
    {
        Destroy(bulletCollider);
        Destroy(gameObject);
    }
}
