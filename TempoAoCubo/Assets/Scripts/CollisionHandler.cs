using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Platform" || c.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
