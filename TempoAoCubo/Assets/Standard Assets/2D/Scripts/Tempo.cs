using UnityEngine;
using System.Collections;

public class Tempo : MonoBehaviour {

	public void setTime(float start)
	{
		GetComponentInChildren<UnityEngine.UI.Text>().text = "You lost " + (Time.unscaledTime).ToString("F3") + " seconds...";
	}
}
