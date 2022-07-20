using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class txt : MonoBehaviour
{
    public GameObject GOHandCardPrefab; //手牌預設
    public GameObject GOHandCardPrefab1; //手牌預設
    public GameObject GOHandCardPrefab2; //手牌預設
    private List<GameObject> ListHandCard = new List<GameObject>();//手牌列表
    public GameObject TransBeginHandCard; //生成手牌的最開始的位置
    //public GameObject cude;
    public RectTransform progressUI;
    public Image progressImage;
    public GameObject car;
    public Transform cart;
    public GameObject car1;
    public Transform cart1;
    public GameObject car2;
    public Transform cart2;
    public bool move;
    public static int atc;
    public static int def;
    public static int spe;


    private float _FloRotateAngel;                         //手牌動畫旋轉的角度
                                                           // Use this for initialization
    void Start()
    {
        move = false;
        //cude.SetActive(false);
        progressUI.gameObject.SetActive(false);
        car.SetActive(false);
        car1.SetActive(false);
        car2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            move = true;

        }
        else
        {
            move = false;
        }
        //progressUI.anchoredPosition3D = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
          
                GetCards();
                RotateAngel();
                AddCardAnimations();
            


        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            UseCardAnimation();
        }
        //if (move == false)
        //{
        //    if (c == 0)
        //    {
        //        GetCards();
        //        RotateAngel();
        //        AddCardAnimations();
        //    }
        //    else if (c == 1)
        //    {
        //        GetCards1();
        //        RotateAngel();
        //        AddCardAnimations();
        //    }
        //    else if (c == 2)
        //    {
        //        GetCards2();
        //        RotateAngel();
        //        AddCardAnimations();
        //    }
        //    car.SetActive(false);
        //    car1.SetActive(false);
        //    car2.SetActive(false);
        //}

    }

    public void GetCards()
    {
        //克隆預設
        GameObject GOHandCard = GameObject.Instantiate(GOHandCardPrefab) as GameObject;
        GOHandCard.transform.position = TransBeginHandCard.transform.position;
        GOHandCard.transform.parent = this.transform;
        //將新手牌添加到手牌列表
        ListHandCard.Add(GOHandCard);
        //計算動畫需要旋轉的角度
        RotateAngel();

    }
    public void GetCards1()
    {
        //克隆預設
        GameObject GOHandCard = GameObject.Instantiate(GOHandCardPrefab1) as GameObject;
        GOHandCard.transform.position = TransBeginHandCard.transform.position;
        GOHandCard.transform.parent = this.transform;
        //將新手牌添加到手牌列表
        ListHandCard.Add(GOHandCard);
        //計算動畫需要旋轉的角度
        RotateAngel();

    }
    public void GetCards2()
    {
        //克隆預設
        GameObject GOHandCard = GameObject.Instantiate(GOHandCardPrefab2) as GameObject;
        GOHandCard.transform.position = TransBeginHandCard.transform.position;
        GOHandCard.transform.parent = this.transform;
        //將新手牌添加到手牌列表
        ListHandCard.Add(GOHandCard);
        //計算動畫需要旋轉的角度
        RotateAngel();

    }
    //爲手牌添加動畫
    private void HandCardAnimation(GameObject GO, float Vec3_Z)
    {
        GO.transform.DORotate(new Vector3(0, 0, Vec3_Z), 0.3F, RotateMode.Fast);
    }
    //增加手牌時播放的動畫
    private void AddCardAnimations()
    {
        if (ListHandCard.Count == 1)
        {
            HandCardAnimation(ListHandCard[0], 0);
        }
        else
        {
            for (int i = 1; i < ListHandCard.Count; i++)
            {
                HandCardAnimation(ListHandCard[i - 1], 30 - _FloRotateAngel * (float)i * ListHandCard.Count + 2.5F);
            }
            HandCardAnimation(ListHandCard[ListHandCard.Count - 1], -27.5F + _FloRotateAngel);
        }
    }
    //使用手牌時播放的動畫
    public void UseCardAnimation()
    {
        Destroy(ListHandCard[0]);
        ListHandCard.Remove(ListHandCard[0]);
        RotateAngel();
        if (ListHandCard.Count == 1)
        {
            HandCardAnimation(ListHandCard[0], 0);
        }
        else if (ListHandCard.Count > 1)
        {
            for (int i = 1; i < ListHandCard.Count + 1; i++)
            {
                HandCardAnimation(ListHandCard[i - 1], 30 - _FloRotateAngel * (float)i * ListHandCard.Count + 2.5F);
                HandCardAnimation(ListHandCard[ListHandCard.Count - 1], -27.5F + _FloRotateAngel);
            }
        }
        

        if (move == true)
        {
            //progressUI.anchoredPosition3D = Input.mousePosition;
            //progressUI.gameObject.SetActive(true);
            car.SetActive(true);
            cart.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        }

    }
    public void UseCardAnimation1()
    {
        Destroy(ListHandCard[0]);
        ListHandCard.Remove(ListHandCard[0]);
        RotateAngel();
        if (ListHandCard.Count == 1)
        {
            HandCardAnimation(ListHandCard[0], 0);
        }
        else if (ListHandCard.Count > 1)
        {
            for (int i = 1; i < ListHandCard.Count + 1; i++)
            {
                HandCardAnimation(ListHandCard[i - 1], 30 - _FloRotateAngel * (float)i * ListHandCard.Count + 2.5F);
                HandCardAnimation(ListHandCard[ListHandCard.Count - 1], -27.5F + _FloRotateAngel);
            }
        }
        if (move == true)
        {
            //progressUI.anchoredPosition3D = Input.mousePosition;
            //progressUI.gameObject.SetActive(true);
            car1.SetActive(true);
            cart1.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        }

    }
    public void UseCardAnimation2()
    {
        Destroy(ListHandCard[0]);
        ListHandCard.Remove(ListHandCard[0]);
        RotateAngel();
        if (ListHandCard.Count == 1)
        {
            HandCardAnimation(ListHandCard[0], 0);
        }
        else if (ListHandCard.Count > 1)
        {
            for (int i = 1; i < ListHandCard.Count + 1; i++)
            {
                HandCardAnimation(ListHandCard[i - 1], 30 - _FloRotateAngel * (float)i * ListHandCard.Count + 2.5F);
                HandCardAnimation(ListHandCard[ListHandCard.Count - 1], -27.5F + _FloRotateAngel);
            }
        }
        if (move == true)
        {
            //progressUI.anchoredPosition3D = Input.mousePosition;
            //progressUI.gameObject.SetActive(true);
            car2.SetActive(true);
            cart2.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        }

    }
    //計算需要旋轉的角度
    private void RotateAngel()
    {
        _FloRotateAngel = 55F / (float)ListHandCard.Count / (float)ListHandCard.Count;
    }
}

