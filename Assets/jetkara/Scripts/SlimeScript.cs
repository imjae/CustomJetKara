using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
