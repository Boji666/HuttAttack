using UnityEngine;
using System.Collections;

public class DragDropSpell :MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 screenPoint;
	private Vector3 offset;
	private bool spellClicked = false;


	public GameObject papirus;
	public GameObject spellPrefab;
	public Grid grid;
	public DestroySpell dp;

	void Start ()
	{
		startPosition = gameObject.transform.localPosition;

	}

	void OnMouseDown()
	{
		
		if (Input.GetMouseButtonDown (0)) 
		{
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
																								Input.mousePosition.y,
																								screenPoint.z));
			spellClicked = true;
		}

	}


	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

	}



	// Update is called once per frame
	void Update()
	{ 
			
		if (Input.GetMouseButtonUp(0) && spellClicked)
		{
			spellClicked = false;
			Transform go = transform.GetChild(0);

			if (go.gameObject.name == "Fireball"){
				Instantiate(spellPrefab,papirus.transform);
				grid.ClearFireball();
				spellPrefab.transform.localPosition = startPosition;
				dp.DestroyFirstChild();
			}

			else if (go.gameObject.name == "Lightning"){
				Instantiate(spellPrefab,papirus.transform);
				grid.ClearLightning();
				spellPrefab.transform.localPosition = startPosition;
				dp.DestroyFirstChild();
			}

			else if (go.gameObject.name == "Ice"){
				Instantiate(spellPrefab,papirus.transform);
				grid.ClearIce();
				spellPrefab.transform.localPosition = startPosition;
				dp.DestroyFirstChild();
			}

		}
		

	}




}
