using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{

	public string targetScene;


	public void Play()
	{
		SceneManager.LoadScene("Level2");
	}

	public void Exit()
	{
		Application.Quit();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//We overlapped
		//Check if its the player
		if (collision.CompareTag("Player"))
		{
			//It is the player!


			//Change Scene
			SceneManager.LoadScene(targetScene);
		}
	}
}
