using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float moveSpeed = 25f;
    Vector2 startPos;
    Vector2 Movement;

    [SerializeField]
    private Rigidbody2D objectRigidobody2d;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        Movement = new Vector2(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void FixedUpdate()
    {
        if (null != objectRigidobody2d)
            objectRigidobody2d.velocity = Movement * moveSpeed;
    }

}
