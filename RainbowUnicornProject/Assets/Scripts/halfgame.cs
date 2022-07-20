using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class halfgame : MonoBehaviour
{
    public GameObject all;
    public GameObject music;

    private void Start()
    {
       all = GameObject.Find("DontDestoryOnLoad");
       music = GameObject.Find("Funny Comedy Background Music No Copyright");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerMove")
        {
            Destroy(all);
            Destroy(music);
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("HP", 100);
        }
    }
}
