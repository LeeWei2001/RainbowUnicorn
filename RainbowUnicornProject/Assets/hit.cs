using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();//取得粒子
    }

    // Update is called once per frame
    void Update()
    {
        /*if (ps.IsAlive() == false)//判斷粒子是否存活
        {
            Destroy(this.gameObject);
        }*/
    }
}
