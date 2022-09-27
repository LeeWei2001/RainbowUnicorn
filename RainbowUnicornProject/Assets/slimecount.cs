using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimecount : MonoBehaviour
{
    public Animator Frount01;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.currentHealth == 0)
        {
            Frount01.SetBool("dead", true);
            Invoke("dead", 1);
        }
    }
    void dead()
    {
        Destroy(this.gameObject);
    }
}
