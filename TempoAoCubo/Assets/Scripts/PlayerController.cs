using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D body;
    private bool grounded;
    public float maxSpeed = 5f;
    public float jumpTime = 5f;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        grounded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    void FixedUpdate()
    {
        print(grounded);
        //Vector2 v = Vector2.right * maxSpeed * Input.GetAxis("Horizontal");
        body.velocity = Vector2.right * maxSpeed * Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            body.AddForce(Vector2.up * 125f, ForceMode2D.Impulse);
            //body.velocity += 250f * Vector2.up;
            grounded = false;
            //StartCoroutine(JumpRoutine());
        }
    }

    IEnumerator JumpRoutine()
    {
        body.velocity = Vector2.zero;
        float timer = 0;

        while (Input.GetKeyDown(KeyCode.W) && timer < jumpTime)
        {
            //Calculate how far through the jump we are as a percentage
            //apply the full jump force on the first frame, then apply less force
            //each consecutive frame

            //float proportionCompleted = timer / jumpTime;
            //Vector2 thisFrameJumpVector = Vector2.Lerp(Vector2.up * 100f, Vector2.zero, proportionCompleted);
            body.AddForce(Vector2.up * 100f);
            //body.AddForce(thisFrameJumpVector);
            timer += Time.deltaTime;
            yield return null;
        }

        grounded = true;
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
