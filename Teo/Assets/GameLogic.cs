using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	float timeRemaining = 4500f; 
	float timeExtension = 3f; 
	float timeDeduction = 2f; 
	float totalTimeElapsed = 0;   
	float score=0f; 
	public GUISkin scoreText;
	public bool isGameOver = false;

	void Start () {
		Time.timeScale = 1;
	}


	void Update () {
		if(isGameOver)
			return;      //move out of the function

		totalTimeElapsed += Time.deltaTime; 

		timeRemaining -= Time.deltaTime;
		if(timeRemaining <= 0){
			isGameOver = true;
		}
	}

	public void GetItems()
	{
		timeRemaining += timeExtension; 
		score = score+1;
	}

	public void CrashFire()
	{
		timeRemaining -= timeDeduction; 
	}

	void OnGUI()
	{
		GUI.skin=scoreText; 
		if(!isGameOver)    
		{
			GUI.Label(new Rect(10, 50, Screen.width/5, 
				Screen.height/6),
				"เวลา: "+((int)timeRemaining).ToString());
			GUI.Label(new Rect(Screen.width-(Screen.width/6), 10, 
				Screen.width/6, Screen.height/6), 
				"คะแนน: "+((int)score).ToString());
		}

		else
		{
			Time.timeScale = 0;

			//Show Total Score
			GUI.Box(new Rect(Screen.width/4, 
				Screen.height/4, 
				Screen.width/2, 
				Screen.height/2), 
				"GAME OVER\nYOUR SCORE: "+(int)score);

			//Restart Game
			if (GUI.Button(new Rect(Screen.width/4+10, 
				Screen.height/4+Screen.height/10+10, 
				Screen.width/2-20, Screen.height/10), 
				"RESTART")){
				Application.LoadLevel(Application.loadedLevel);
			}

		}
	}

}