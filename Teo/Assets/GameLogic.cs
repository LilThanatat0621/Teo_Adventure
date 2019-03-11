using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLogic : MonoBehaviour {
	// Text m_text;
	// public Font m_text;	
	float timeRemaining = 4500f;
	float timeExtension = 3f;
	float timeDeduction = 2f;
	float totalTimeElapsed = 0;
	public Texture aTexture;
	float score = 0f;
	public GUISkin scoreText;
	public bool isGameOver = false;
	public bool trigger  =false;
	void Start () {
		Time.timeScale = 1;
		// m_text = GetComponent<Text>();
	}

	void Update () {
		if (isGameOver)
			return; //move out of the function

		totalTimeElapsed += Time.deltaTime;

		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0) {
			isGameOver = true;
		}
	}

	public void GetItems () {
		timeRemaining += timeExtension;
		score = score + 1;
	}

	public void CrashFire () {
		timeRemaining -= timeDeduction;
	}

	void OnGUI () {
		GUI.skin = scoreText;

		 if(trigger)
		{
			Forever[] allChildren = GameObject.FindWithTag ("CodeContent").transform.GetComponentsInChildren<Forever> ();
				foreach (Forever child in allChildren) {
					if (child.isForeverBlock) child.Stop ();
				}
		Time.timeScale = 0;
			if (GUI.Button (new Rect (Screen.width / 4 ,
						Screen.height / 4 + Screen.height / 10 + 10,
						Screen.width / 2  , Screen.height / 10),
					"MAIN MENU")) {
				
				SceneManager.LoadScene ("Title");
			}
		
			if (!aTexture)
        {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }

        GUI.DrawTexture(new Rect(Screen.width / 15 -70,
						Screen.height / 6,
						Screen.width , Screen.height / 2-250), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
		} 
		
		if(isGameOver) {
			Time.timeScale = 0;

			//Show Total Score
			GUI.Box (new Rect (Screen.width / 4,
					Screen.height / 4,
					Screen.width / 2 ,
					Screen.height / 2),
				"GAME OVER\n" );

			//Restart Game
			if (GUI.Button (new Rect (Screen.width / 4 + 10,
						Screen.height / 4 + Screen.height / 10 + 10,
						Screen.width / 2 - 20, Screen.height / 10),
					"RESTART")) {
				Forever[] allChildren = GameObject.FindWithTag ("CodeContent").transform.GetComponentsInChildren<Forever> ();
				foreach (Forever child in allChildren) {
					if (child.isForeverBlock) child.Stop ();
				}
				Application.LoadLevel (Application.loadedLevel);
			}

		}
	}

}