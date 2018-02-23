using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundMM : MonoBehaviour {

    private static SoundMM instance;
    

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (!instance.GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();

        
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3")
        {
            Destroy(this.gameObject);
            instance = null;
        }
    }

    public void turnMusicOff()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            instance = null;
        }
    }

    void OnApplicationQuit()
    {
        instance = null;
    }
}
