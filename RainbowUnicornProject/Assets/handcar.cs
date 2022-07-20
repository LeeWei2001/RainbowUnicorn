using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handcar : MonoBehaviour
{
    public GameObject atce;
    public GameObject hadcar;
    // Start is called before the first frame update
    void Start()
    {
        atce.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ondown()
    {
        atce.SetActive(true);
        hadcar.SetActive(false);
    }
}
