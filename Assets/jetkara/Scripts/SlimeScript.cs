using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public GameObject healthBar;
    public int slimeScore = 100;
    public float slimeSpeed = 0.07f;

    private bool isDead;
    private Animator animator;
    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        animator = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthSystem healthSystem = healthBar.GetComponent<HealthSystem>();
        if (healthSystem.hitPoint <= 0 && !isDead)
        {
            GameManager.instance.AddScore(slimeScore);
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
        transform.position = new Vector3(transform.position.x - slimeSpeed, transform.position.y, 0f);

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
