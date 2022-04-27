using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematics : MonoBehaviour
{
    public VideoPlayer cinematic;
    public string sceneToLoad;
    private bool ended = false;

    void Update()
    {
        if (!cinematic.isPlaying && !ended)
        {
            ended = true;
            SceneManager.LoadScene(sceneToLoad);
            //Debug.Log("End");
        }
    }
}
