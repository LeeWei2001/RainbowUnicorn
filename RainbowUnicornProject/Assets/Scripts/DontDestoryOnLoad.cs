using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoryOnLoad : MonoBehaviour
{
    public GameObject Player;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        
    }

    private void Update()
    {

        string name = SceneManager.GetActiveScene().name;

        if (name != "MapX")
        {
            Player.SetActive(false);
        }
        else
        {
            Player.SetActive(true);
        }
    }



}
