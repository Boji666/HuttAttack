using UnityEngine;
using System.Collections;

public class DestroySpell : MonoBehaviour {
	
	public void DestroyFirstChild()
	{ 
		Transform go = transform.GetChild(1);
		Destroy(go.gameObject);
	}
}
