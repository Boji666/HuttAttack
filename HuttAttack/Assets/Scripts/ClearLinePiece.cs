using UnityEngine;
using System.Collections;

public class ClearLinePiece : ClearablePiece {

	public bool isRow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Clear()
	{
		base.Clear();

		if (isRow)
		{
			// Clear row
			piece.GridRef.ClearRow(piece.Y);
		}
		else
		{
			// Clear column
			piece.GridRef.ClearColumn(piece.X);
		}
	}
}
