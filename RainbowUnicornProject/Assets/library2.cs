using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class library2 : MonoBehaviour
{
    public GameObject[] Objects; //�˥ͦ����󪺰}�C�C

    public Transform[] Points; //�˥ͦ��I���}�C�C

    public float Ins_Time = 1; //�C�X��ͦ��@���C

    //public ���} �V




    void Start()

    {

        InvokeRepeating("Ins_Objs", Ins_Time, Ins_Time);


        //���ƩI�s(���禡�W���A�Ĥ@�����j�X��I�s�A�C�X��I�s�@��)�C

    }



    void Ins_Objs() //�ͦ�����禡�C

    {


        int Random_Objects = Random.Range(0, Objects.Length);

        //�H������0~����}�C���ת����-1(���]�t�̤j�ȩҥH-1)�C



        int Random_Points = Random.Range(0, Points.Length);

        //�H������0~�ͦ��I�}�C���ת����-1(���]�t�̤j�ȩҥH-1)�C



        Instantiate(Objects[Random_Objects], Points[Random_Points].transform.position, Points[Random_Points].transform.rotation);

        //Instantiate��Ҥ�(�n�ͦ�������, �����m, ��������);

        specardmove.isMove = true;
        uicontrol.m_speciallibrary++;


    }

}
