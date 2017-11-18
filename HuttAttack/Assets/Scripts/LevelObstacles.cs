using UnityEngine;
using System.Collections;

public class LevelObstacles : Level {

	public int numMoves;
	public Grid.PieceType[] obstaclesTypes;

	private int movesUsed = 0;
	private int numObstaclesLeft;

	// Use this for initialization
	void Start () {
		type = LevelType.OBSTACLE;

		for (int i = 0; i < obstaclesTypes.Length; i++)
		{
			numObstaclesLeft += grid.GetPiecesOfType(obstaclesTypes[i]).Count;
		}

		hud.SetLevelType(type);
		hud.SetScore(currentScore);
		hud.SetTarget(numObstaclesLeft);
		hud.SetRemaining(numMoves);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnMove ()
	{
		movesUsed++;

		hud.SetRemaining (numMoves - movesUsed);

		//Debug.Log("Moves remaining: " + (numMoves - movesUsed));

		if (numMoves - movesUsed == 0 && numObstaclesLeft > 0)
		{
			GameLose();
		}
	}


	public override void OnPieceCleared (GamePiece piece)
	{
		base.OnPieceCleared(piece);

		for (int i = 0; i < obstaclesTypes.Length; i++)
			if(obstaclesTypes [i] == piece.Type)
			{
				numObstaclesLeft--;
				hud.SetTarget(numObstaclesLeft);

				if (numObstaclesLeft == 0)
				{
					currentScore += 100 * (numMoves - movesUsed);
					//Debug.Log("CurrentScore: " + currentScore);
					hud.SetScore (currentScore);
					GameWin();
				}
			}
	}
}
