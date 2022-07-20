using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiond : MonoBehaviour
{

    public GameObject GameObject1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            GameObject1.SetActive(false);
        }
    }
    public void setbutton()
    {
        GameObject1.SetActive(true);

    }
    public void quitbutton()
    {
        GameObject1.SetActive(false);

    }
}
