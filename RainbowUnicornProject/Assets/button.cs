using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void starbutton()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("HP", 100);
        PlayerPrefs.DeleteKey("LV");
    }
    public void exitbutton()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif 
    }
    
}
