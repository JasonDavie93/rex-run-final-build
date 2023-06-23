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
			
			currentScene = SceneManager.GetActiveScene().buildIndex;
			if (currentScene == 3)
            {
				SceneManager.LoadScene(5);
				Cursor.visible = true;
			}

            else
            {
				//Change Scene
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}
		}
	}
}
