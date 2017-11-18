using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillBoard : MonoBehaviour {

	float tileSize = 64f;
	float offsetX = 6.9f;
	float offsetY = Screen.height/3;
	static int file = 9;
	static int column = 10;

	bool spawning = false;

	Sprite [] spritesMonsters;
	Sprite [,] spritesBoard = new Sprite[column,file];
	GameObject rootSprites;

	// Use this for initialization
	void Start () {
		Screen.SetResolution(645, 1136, false);
		rootSprites = GameObject.Find ("Canvas");
		spritesMonsters = Resources.LoadAll<Sprite>("Skeletons");
		//fillBoard(spritesMonsters,spritesBoard);

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) == true && spawning == false)
		{
			spawning = true;
			StartCoroutine(fillBoard(spritesMonsters,spritesBoard));

		}
	}

	
	IEnumerator fillBoard (Sprite []spritesMonsters, Sprite [,]spritesBoard)
	{
		RectTransform spriteRect;
		BoxCollider collider;
		GameObject emptyObject;
		float posC = -284.1f;
		float posF = offsetY;

		for (int c = 0; c < column; c++) 
		{
			for (int f = 1; f <= file; f++) 
			{
				//1st Create elem with components
				emptyObject = new GameObject("Item"+ f.ToString() + c.ToString());
				//emptyObject.layer = 5; // Add tu UI layer
				emptyObject.AddComponent<RectTransform> ();
				emptyObject.AddComponent<CanvasRenderer> ();
				emptyObject.AddComponent<Image> ();
				emptyObject.AddComponent<BoxCollider> ();
				//emptyObject.AddComponent<DragAndDropXY> ();
				//2nd Add a sprite to the elem
				emptyObject.GetComponent<Image> ().sprite = spritesMonsters[Random.Range(0,5)];
				//3rd Set item size
				spriteRect = emptyObject.GetComponent<RectTransform> ();
				spriteRect.sizeDelta = new Vector2 (tileSize,tileSize);
				collider = emptyObject.GetComponent<BoxCollider> ();
				collider.size = new Vector3 (tileSize,tileSize,1);
				//4th Add elem into tab
				emptyObject.transform.SetParent (rootSprites.transform, false);
				//5th Position the elem
				spriteRect.localPosition = new Vector3(posC + tileSize*(f-1),posF,0);
				posC+=offsetX;
				yield return new WaitForSeconds(0.1f);
			}
			//New offset to pos tiles on board
			posC = -284.1f;
			posF -= tileSize + offsetX;
		}

		Application.CaptureScreenshot("image.png");
			
	}






}
