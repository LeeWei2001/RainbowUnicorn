using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playingstage2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "playingarea")
        {

            this.gameObject.SetActive(false);
        }
    }
}
