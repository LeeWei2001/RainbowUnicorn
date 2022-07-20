using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator Frount01;
    public GameObject ua;
    public GameObject ua1;
    // Start is called before the first frame update
    void Start()
    {
        ua.SetActive(false);
        ua1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Frount01.SetBool("run", true);
        }
        else
        {
            Frount01.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ua.SetActive(true);
            ua1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ua.SetActive(false);
            ua1.SetActive(true);
        }
    }
}
