using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public float curProgressValue = 0;
    public float progressValue = 10;
    public Image progressImg;
    public Text timetext;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timetext.text = curProgressValue.ToString();
        if (curProgressValue <= progressValue)
        {
            if (curProgressValue >= 0)
            {
                curProgressValue -= Time.deltaTime;
            }
        }
        progressImg.fillAmount = curProgressValue / progressValue;
    }
}