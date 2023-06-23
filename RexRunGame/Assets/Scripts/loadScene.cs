using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
	public int currentScene;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//We overlapped
		//Check if its the player
		if (collision.CompareTag("Player"))
		{
			//It is the player!
			//sets "current scene" to current index
			currentScene = SceneManager.GetActiveScene().buildIndex;
			//if index = 3, the game will load the "win" screen
			if (currentScene == 3)
            {
				SceneManager.LoadScene(5);
				Cursor.visible = true;
			}

            else
            {
				//loads next Scene
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}
}
