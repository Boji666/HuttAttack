using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class Spells : MonoBehaviour {


	public enum SpellType
	{
		FIREBALL,
		LIGHTNING,
		ICE,

	};

	[System.Serializable]
	public struct SpellCoords
	{
		public int x;
		public int y;
	};

	[HideInInspector]
	public List<SpellCoords> fireballRange = new List<SpellCoords> ();
	[HideInInspector]
	public List<SpellCoords> lightningRange = new List<SpellCoords> ();
	[HideInInspector]
	public List<SpellCoords> iceRange = new List<SpellCoords> ();


	// Use this for initialization
	void Awake () {
		initFireball(fireballRange);
		initLightning(lightningRange);
		initIce(iceRange);
	}

	void initFireball(List<SpellCoords> fireballRange){
		
		SpellCoords coordsXY;

		for (int i = -1; i < 2; i++)
		{
			coordsXY.x = i;	
			for (int j = -1; j < 2; j++)
			{
				coordsXY.y = j;
				fireballRange.Add(coordsXY);
			}
		}
	}

	void initLightning(List<SpellCoords> lightningRange){

		SpellCoords coordsXY;

		// diagonal right
		coordsXY.x = 1;
		coordsXY.y = 1;
		lightningRange.Add(coordsXY);

		// diagonal left
		coordsXY.x = -1;
		coordsXY.y = 1;
		lightningRange.Add(coordsXY);

	}

	void initIce(List<SpellCoords> iceRange){

		SpellCoords coordsXY;

		for (int i = -1; i < 2; i++)
		{
			coordsXY.x = i;	
			for (int j = -1; j < 2; j++)
			{
				coordsXY.y = j;
				if (coordsXY.y == 0 && (coordsXY.x == 1 || coordsXY.x == -1) ){
					coordsXY.x *=2;
				}
				if(coordsXY.x == 0 && (coordsXY.y == 1 || coordsXY.y == -1)){
					coordsXY.y *=2;
				}

				Debug.Log("Hielo:" + coordsXY.x+  "," + coordsXY.y);
				iceRange.Add(coordsXY);
				coordsXY.x = i;
			}
		}
	}





}
