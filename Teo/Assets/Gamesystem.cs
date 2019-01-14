using UnityEngine;
using System.Collections;

public class Gamesystem : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	float timeElapsed = 0;
	float ItemCycle = 3f;
	bool oddEnemy = true;
	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed > ItemCycle)
		{
			GameObject temp;
			if(oddEnemy)
			{
				temp = (GameObject)Instantiate(enemy1);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(pos.x, pos.y, pos.z);
			}
			else
			{
				temp = (GameObject)Instantiate(enemy2);
				Vector3 pos = temp.transform.position;
				temp.transform.position = new Vector3(pos.x, pos.y, pos.z);
			}
			timeElapsed -= ItemCycle;
			oddEnemy = !oddEnemy;
		}
	}
}
