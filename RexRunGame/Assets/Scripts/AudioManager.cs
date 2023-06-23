using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Declare a public array of Sound objects named "sounds"
    public Sound[] sounds;
    // Declare an integer variable named "currentScene"
    public int currentScene;

    // Start is called before the first frame update
    void Awake()
    {
        // Iterate through each Sound object in the "sounds" array
        foreach (Sound s in sounds)
        {
            // Add an AudioSource component to the AudioManager GameObject
            s.source = gameObject.AddComponent<AudioSource>();
            // Set the AudioClip of the AudioSource component to the AudioClip specified in the Sound object
            s.source.clip = s.clip;

            // Set the volume of the AudioSource component to the volume specified in the Sound object
            s.source.volume = s.volume;

            // Set the pitch of the AudioSource component to the pitch specified in the Sound object
            s.source.pitch = s.pitch;

            // Set the loop property of the AudioSource component to the loop property specified in the Sound object
            s.source.loop = s.loop;
        }
    }

	 void Start()
	{
        // Get the current scene's build index and assign it to the "currentScene" variable
        currentScene = SceneManager.GetActiveScene().buildIndex;
        // Check if the current scene's build index is 0 or 4
        if (currentScene == 0 || currentScene == 4)
        {
            // Play specific audio clips ("ambientSounds", "ambientSounds2", "ambientSounds3", "ambientSounds4") using the AudioManager
            FindObjectOfType<AudioManager>().Play("ambientSounds");
            FindObjectOfType<AudioManager>().Play("ambientSounds2");
            FindObjectOfType<AudioManager>().Play("ambientSounds3");
            FindObjectOfType<AudioManager>().Play("ambientSounds4");
        }
        else
        {
            // Play specific audio clips ("ambientSounds", "ambientSounds2", "ambientSounds3") using the AudioManager
            FindObjectOfType<AudioManager>().Play("ambientSounds");
            FindObjectOfType<AudioManager>().Play("ambientSounds2");
            FindObjectOfType<AudioManager>().Play("ambientSounds3");
        }
    }
    

   
	public void Play(string name)
    {
        // Find the Sound object in the "sounds" array with the matching name and assign it to the "s" variable
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // Play the AudioClip associated with the Sound object's AudioSource component
        s.source.Play();
    }
   
}