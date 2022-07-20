using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class cardmove : MonoBehaviour
{
    public GameObject PathA;//起點
    public GameObject PathB;//終點
    //public GameObject PathC;//起點
    //public GameObject PathD;
    public GameObject Obj;//要移動的物件
    public int od = 0;
    public float speed = 0.2f;//移動速度
    private float firstSpeed;//紀錄第一次移動的距離
    public static float tmp;
    // Start is called before the first frame update
    void Start()
    {
        firstSpeed = Vector3.Distance(Obj.transform.position, PathB.transform.position) * speed;
        //firstSpeed = Vector3.Distance(Obj.transform.position, PathC.transform.position) * speed;
        //firstSpeed = Vector3.Distance(Obj.transform.position, PathD.transform.position) * speed;

    }

    // Update is called once per frame
    void Update()
    {
        if (od == 1)
        {
            Invoke("play", 0);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            od++;

            //else if (od == 1)
            //{
            //    Obj.transform.position = Vector3.Lerp(Obj.transform.position, PathC.transform.position, speed);
            //    speed = calculateNewSpeed1();
            //    od++;
            //    speed = 1;
            //}
            //else if (od == 2)
            //{
            //    Obj.transform.position = Vector3.Lerp(Obj.transform.position, PathD.transform.position, speed);
            //    speed = calculateNewSpeed2();
            //    od++;
            //}

        }

    }

    private float calculateNewSpeed()
    {
        //因為每次移動都是 Obj 在移動，所以要取得 Obj 和 PathB 的距離
        float tmp = Vector3.Distance(Obj.transform.position, PathB.transform.position);


        //當距離為0的時候，就代表已經移動到目的地了。
        if (tmp == 0)
            return tmp;
        else
            return (firstSpeed / tmp);
    }
    void play()
    {
        Obj.transform.position = Vector3.Lerp(Obj.transform.position, PathB.transform.position, speed);
        speed = calculateNewSpeed();
        
        

    }
    //private float calculateNewSpeed1()
    //{
    //    //因為每次移動都是 Obj 在移動，所以要取得 Obj 和 PathB 的距離
    //    float tmp = Vector3.Distance(Obj.transform.position, PathC.transform.position);


    //    //當距離為0的時候，就代表已經移動到目的地了。
    //    if (tmp == 0)
    //        return tmp;
    //    else
    //        return (firstSpeed / tmp);
    //}
    //private float calculateNewSpeed2()
    //{
    //    //因為每次移動都是 Obj 在移動，所以要取得 Obj 和 PathB 的距離
    //    float tmp = Vector3.Distance(Obj.transform.position, PathD.transform.position);


    //    //當距離為0的時候，就代表已經移動到目的地了。
    //    if (tmp == 0)
    //        return tmp;
    //    else
    //        return (firstSpeed / tmp);
    //}
}
