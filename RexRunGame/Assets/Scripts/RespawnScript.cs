using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScript : MonoBehaviour
{

    public float delay = 3f;
    public int respawnScene;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnSceneRoutine());
    }

    IEnumerator RespawnSceneRoutine()
    {
        yield return new WaitForSeconds(delay);
        RespawnScene();
    }

     void RespawnScene()
    {
        respawnScene = SceneManager.GetActiveScene().buildIndex;
    }
}
