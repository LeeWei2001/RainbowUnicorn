using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class change : MonoBehaviour
{
    public GameObject txt;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;
    public GameObject txt5;
    public GameObject txt6;
    // Start is called before the first frame update
    void Start()
    {
        txt.SetActive(false);
        txt2.SetActive(false);
        txt3.SetActive(false);
        txt4.SetActive(false);
        txt5.SetActive(false);
        txt6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flowchart.BroadcastFungusMessage("enter");
        }
    }
    public void Battle()
    {
        SceneManager.LoadScene("Slime");
    }
    public void coick()
    {
        txt6.SetActive(false);
    }
   public void wait()
    {
        txt.SetActive(true);
    } 
    public void wait1()
    {
        txt2.SetActive(true);
        txt.SetActive(false);
    }
    public void wait2()
    {
        txt3.SetActive(true);
        txt2.SetActive(false);
    }
    public void wait3()
    {
        txt4.SetActive(true);
        txt3.SetActive(false);
    }
    public void wait4()
    {
        txt5.SetActive(true);
        txt4.SetActive(false);
    }
    public void wait5()
    {
        txt6.SetActive(true);
        txt5.SetActive(false);
    }
}
