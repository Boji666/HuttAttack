using UnityEngine;
using System.Collections;

public class LevelSelected : MonoBehaviour {

	[System.Serializable]
	public struct ButtonPlayersPrefs
	{
		public GameObject gameObject;
		public string playerPrefKey;
	}

	public ButtonPlayersPrefs[] buttons;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < buttons.Length; i++)
		{
			int score = PlayerPrefs.GetInt(buttons[i].playerPrefKey,0);

			for(int starIdx = 1; starIdx <= 3; starIdx++)
			{
				Transform star = buttons [i].gameObject.transform.Find("star" + starIdx);

				if (starIdx <= score){
					star.gameObject.SetActive(true);
				}else{
					star.gameObject.SetActive(false);
				}
			}
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnButtonPress (string levelName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
	}
}
