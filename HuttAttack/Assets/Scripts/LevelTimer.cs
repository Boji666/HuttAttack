using UnityEngine;
using System.Collections;

public class LevelTimer : Level {

	public int timeInSeconds;
	public int targetScore;

	private float timer;
	private bool timeOut;

	// Use this for initialization
	void Start () {
		type = LevelType.TIMER;

		hud.SetLevelType(type);
		hud.SetScore(currentScore);
		hud.SetTarget(targetScore);
		hud.SetRemaining(string.Format("{0}:{1:00}", timeInSeconds / 60, timeInSeconds % 60));

		//Debug.Log("Time: "+ timeInSeconds + "sceond. Target score: " + targetScore);
	}
	
	// Update is called once per frame
	void Update () {
		if (!timeOut)
		{
			timer += Time.deltaTime;
			hud.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer),0) / 60,  (int)Mathf.Max((timeInSeconds - timer),0) % 60));

			if (timeInSeconds - timer <= 0)
			{
				if (currentScore >= targetScore)
				{
					GameWin();
				}else
				{
					GameLose();
				}

				timeOut = true;
			}
		}
	}
}
