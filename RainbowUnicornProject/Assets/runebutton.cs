using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runebutton : MonoBehaviour
{
    public static int q;
    public static int w;
    public static int e;
    public static int Startq = 0;
    public static int Startw = 0;
    public static int Starte = 0;

    public bool c;
    public Text frequency;
    public Text frequency1;
    public Text frequency2;

    public float qcoldTime = 2.0f;//定義技能的冷卻時間
    public float wcoldTime = 2.0f;
    public float ecoldTime = 2.0f;

    private float timer = 0;//定義計時器
    private float timer1 = 0;
    private float timer2 = 0;

    //public Image filledImage;//定義一個填充圖片，下面從start方法裏獲取實例中的填充圖片
    public bool isStartTime = false;//定義標誌量，決定是否開始計時
    public bool isStartTimew = false;
    public bool isStartTimee = false;

    // Use this for initialization
    void Start()
    {
        q = Startq;
        w = Startw;
        e = Starte;

        //filledImage = transform.Find("FillImage").GetComponent<Image>();//用transform中的Find方法獲取名爲FillImage物體中Image組件；
    }

    // Update is called once per frame
    void Update()
    {
        frequency.text = q.ToString();
        frequency1.text = w.ToString();
        frequency2.text = e.ToString();
        if (isStartTime == false && q <= 8)
        {
            timer += Time.deltaTime;
            if (timer >= qcoldTime)
            {
                timer = 0;
                q += 1;
            }
        }
        if (isStartTimew == false && w <= 8)
        {
            timer1 += Time.deltaTime;
            if (timer1 >= wcoldTime)
            {
                timer1 = 0;
                w += 1;
            }
        }
        if (isStartTimee == false && e <= 4)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= ecoldTime)
            {
                timer2 = 0;
                e += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Invoke("OnShow", 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Invoke("OnShoww", 0);
        }
        if (Input.GetKeyDown(KeyCode.E) && playingarea.card == 0)
        {
            Invoke("OnShowe", 0);
        }

    }
    public void OnShow()//定義一個點擊按妞觸發的方法
    {
        if (q > 0)
        {
            q -= 1;
        }

    }
    public void OnShoww()//定義一個點擊按妞觸發的方法
    {
        if (w > 0)
        {
            w -= 1;
        }

    }
    public void OnShowe()//定義一個點擊按妞觸發的方法
    {
        if (e > 0)
        {
            e -= 1;
        }

    }//特殊
}