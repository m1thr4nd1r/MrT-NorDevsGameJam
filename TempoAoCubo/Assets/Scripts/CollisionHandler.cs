using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (body.velocity.magnitude < 0.1)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Platform" || c.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
