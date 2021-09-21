using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public GameObject healthBar;

    private bool isDead;
    private Animator animator;
    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthSystem healthSystem = healthBar.GetComponent<HealthSystem>();
        if (healthSystem.hitPoint <= 0 && !isDead)
        {
            isDead = true;
            Destroy(collider);
            animator.SetTrigger("Death");
        }
    }

    void SlimeDeath()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, 0f);

        if (transform.position.x <= -7.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
        {
            GameObject colBullet = collision.gameObject;

            BulletScript colBulletScript = colBullet.GetComponent<BulletScript>();
            int damage = colBulletScript.Damage;

            healthBar.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }
}
