using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {

    GameObject player, lastPlatform, template, newPlatform, sand;

    float fix;
	float begin;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //sand = GameObject.FindGameObjectWithTag("Sand");
        sand = Resources.Load<GameObject>("Sand");
        lastPlatform = newPlatform = null;
        template = GameObject.FindGameObjectWithTag("Platform");
        //InvokeRepeating("platGen", 0, 5);
        InvokeRepeating("IncreaseCamera", 0.05f, 0.05f);
        InvokeRepeating("dropSand", 0, 0.5f);
        fix = 0;
		begin = Time.time;
		//goLeft();
    }

    void dropSand()
    {
        GameObject ob = Instantiate(sand);
        ob.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, 1, 10));
    }

    void IncreaseCamera()
    {
		Vector3 v = Vector3.up * 0.05f;

		if (Time.time - begin > 5 && Time.time - begin < 13)
			v += Vector3.right * 0.05f;
		else if (Time.time - begin > 26 && Time.time - begin < 30)
			v += Vector3.left * 0.05f;

		print("Time - begin: " + (Time.time - begin));
		transform.position += v;
    }
	
	public void goLeft()
	{
		transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.left * 5, 3/5);
	}

	public void goRight()
	{
		transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.left * 5, 10f);
	}

	public void StopCamera()
	{
		StopAllCoroutines();
	}

    void platGen()
    {
        newPlatform = Instantiate(template);
        if (lastPlatform != null)
            fix = lastPlatform.transform.position.x > Camera.main.pixelWidth / 2 ? 0.5f : -0.5f;
        newPlatform.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.Clamp(Random.value + fix, 0, 1), 1));//Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane)) + Vector3.right * Random.Range(5, Camera.main.pixelWidth - 5);
        //newPlatform.transform.position = new Vector3(newPlatform.transform.position.x, 2 + (lastPlatform != null ? lastPlatform.transform.position.y : player.transform.position.y), 0);
        lastPlatform = newPlatform;
    }
}
