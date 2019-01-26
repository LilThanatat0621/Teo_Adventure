using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movescene : MonoBehaviour {
   [SerializeField] private string newLevel;
   // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
         Debug.Log("Colled");
         SceneManager.LoadScene(newLevel);
         // Application.LoadLevel(1);
      }
   }

}