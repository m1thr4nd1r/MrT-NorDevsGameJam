using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D body;
    private bool grounded;
    public float maxSpeed = 5f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    void FixedUpdate()
    {
        print(grounded);
        //Vector2 v = Vector2.right * maxSpeed * Input.GetAxis("Horizontal");
        body.velocity = Vector2.right * maxSpeed * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && grounded)
            body.AddForce(Vector2.up * 250f , ForceMode2D.Impulse);
            //body.velocity += 250f * Vector2.up;
    }

    void die()
    {
        Time.timeScale = 0;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.name.Equals("Floor") ||
            c.collider.name.Equals("Platform"))
            grounded = true;
        else if (c.collider.name.Contains("Wall"))
            die();
    }

    void OnCollisionExit2D(Collision2D c)
    {
        if (c.collider.name.Equals("Floor") ||
            c.collider.name.Equals("Platform"))
            grounded = false;
    }
}
