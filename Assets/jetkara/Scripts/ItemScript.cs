using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float startSpeed = 30;

    [SerializeField]
    private Rigidbody2D objectRigidobody2d;

    // Use this for initialization
    void Start()
    {
        float randomX, randomY;
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);

        Vector2 vector2 = new Vector2(randomX, randomY);
        vector2 = vector2.normalized;
        Debug.Log(vector2);

        objectRigidobody2d.velocity = vector2 * startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("z");
    }
}
