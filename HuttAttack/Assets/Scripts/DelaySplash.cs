using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DelaySplash : MonoBehaviour {

	public string levelLoad;
	public float minimum = 0.0f;
	public float maximum = 1f;
	public float duration = 3.0f;
	private float startTime;
	public Image image;

	void Start()
	{
		startTime = Time.time;
		StartCoroutine(TimeDelay());
	}

	void Update() 
	{
		float t = (Time.time - startTime) / duration;
		image.color = new Color(1f,1f,1f,Mathf.SmoothStep(minimum, maximum, t)); 
	}
	

	//This is a coroutine
	IEnumerator TimeDelay()
	{
		
		yield return new WaitForSeconds(4);    //Wait one frame

		SceneManager.LoadScene (levelLoad);

	}
}
