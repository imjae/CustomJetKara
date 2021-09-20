using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    private Transform healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, 0f);

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

            healthBar.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
        }
        
    }
}
