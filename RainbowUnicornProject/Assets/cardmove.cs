using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class cardmove : MonoBehaviour
{
    public GameObject PathA;//�_�I
    public GameObject PathB;//���I
    //public GameObject PathC;//�_�I
    //public GameObject PathD;
    public GameObject Obj;//�n���ʪ�����
    public int od = 0;
    public float speed = 0.2f;//���ʳt��
    private float firstSpeed;//�����Ĥ@�����ʪ��Z��
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
        //�]���C�����ʳ��O Obj �b���ʡA�ҥH�n���o Obj �M PathB ���Z��
        float tmp = Vector3.Distance(Obj.transform.position, PathB.transform.position);


        //��Z����0���ɭԡA�N�N��w�g���ʨ�ت��a�F�C
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
    //    //�]���C�����ʳ��O Obj �b���ʡA�ҥH�n���o Obj �M PathB ���Z��
    //    float tmp = Vector3.Distance(Obj.transform.position, PathC.transform.position);


    //    //��Z����0���ɭԡA�N�N��w�g���ʨ�ت��a�F�C
    //    if (tmp == 0)
    //        return tmp;
    //    else
    //        return (firstSpeed / tmp);
    //}
    //private float calculateNewSpeed2()
    //{
    //    //�]���C�����ʳ��O Obj �b���ʡA�ҥH�n���o Obj �M PathB ���Z��
    //    float tmp = Vector3.Distance(Obj.transform.position, PathD.transform.position);


    //    //��Z����0���ɭԡA�N�N��w�g���ʨ�ت��a�F�C
    //    if (tmp == 0)
    //        return tmp;
    //    else
    //        return (firstSpeed / tmp);
    //}
}
