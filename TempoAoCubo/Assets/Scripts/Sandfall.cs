using UnityEngine;
using System.Collections;

public class Sandfall : MonoBehaviour {

	GameObject sand;

	public float dropTime = 0.05f;

	void Start () {
        sand = Resources.Load<GameObject>("Sand");
		InvokeRepeating("generate", dropTime, dropTime);
	}

	void generate()
	{
		GameObject ob = Instantiate(sand);
		ob.transform.position = transform.position;		
	}
}
