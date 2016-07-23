using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {

    GameObject player, lastPlatform, template, newPlatform;

    float fix;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlatform = newPlatform = null;
        template = GameObject.FindGameObjectWithTag("Platform");
        //InvokeRepeating("platGen", 0, 5);
        InvokeRepeating("IncreaseCamera", 0.05f, 0.05f);
        fix = 0;
    }

    void IncreaseCamera()
    {
        Camera.main.gameObject.transform.position += Vector3.up * 0.05f;
    }
	
    void platGen()
    {
        newPlatform = Instantiate<GameObject>(template);
        if (lastPlatform != null)
            fix = lastPlatform.transform.position.x > Camera.main.pixelWidth / 2 ? 0.5f : -0.5f;
        newPlatform.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.Clamp(Random.value + fix, 0, 1), 1));//Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane)) + Vector3.right * Random.Range(5, Camera.main.pixelWidth - 5);
        //newPlatform.transform.position = new Vector3(newPlatform.transform.position.x, 2 + (lastPlatform != null ? lastPlatform.transform.position.y : player.transform.position.y), 0);
        lastPlatform = newPlatform;
    }
}
