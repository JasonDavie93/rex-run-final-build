using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public int currentScene;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

	 void Start()
	{
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0 || currentScene == 4)
        {
            FindObjectOfType<AudioManager>().Play("ambientSounds");
            FindObjectOfType<AudioManager>().Play("ambientSounds2");
            FindObjectOfType<AudioManager>().Play("ambientSounds3");
            FindObjectOfType<AudioManager>().Play("ambientSounds4");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("ambientSounds");
            FindObjectOfType<AudioManager>().Play("ambientSounds2");
            FindObjectOfType<AudioManager>().Play("ambientSounds3");
        }
    }
    

   
	public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
   
}