using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class actcardmove : MonoBehaviour
{
    public GameObject cube;
    public static bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        Tweener tweener = cube.transform.DOLocalMove(new Vector3(-5.8f, -2.02f, 1.11f), 2f);
        tweener.SetAutoKill(false);//�T��۰ʾP��ʵe
        tweener.Pause();//�Ȱ�
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove==true)
        {
            cube.transform.DOPlayForward();//����
            isMove = true;
        }
    }
   
}
