using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    
   public void PlayGame()
    {
        Cursor.visible = false; //Disables mouse cursor
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads first scene
       
    }


    public void QuitGame()
    {
        //If "Cancel" pressed, game exits to main menu
        if (Input.GetButtonDown("Cancel"))
        {
            //Loads menu
            SceneManager.LoadScene(0);
        }
    }
    public void MainMenu()
    {
        //Loads menu scene
        SceneManager.LoadScene(0);
        
    }

    public void LoadSceneByBuildIndex(int buildIndex)
    {
        
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Debug.Log("Quit Activated");
        Application.Quit();
    }
}
