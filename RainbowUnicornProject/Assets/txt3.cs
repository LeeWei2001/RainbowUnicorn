using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class txt3 : MonoBehaviour
{
    public static int fighting;
    private int lv;
    public BoxCollider trigger;
    // Start is called before the first frame update
    void Start()
    {
        lv = PlayerPrefs.GetInt("LV");
        fighting = 0;
        trigger = this.GetComponent<BoxCollider>();
        PlayerPrefs.DeleteKey("LV");
    }

    // Update is called once per frame
    void Update()
    {
        lv = PlayerPrefs.GetInt("LV");
        //Debug.Log("LV" + lv.ToString());
    }
    void OnTriggerEnter(Collider collider)
    {
        Invoke("fungusopen", 0.5f);
        if (collider.tag == "Player"&&lv==0)
        {

            Flowchart.BroadcastFungusMessage("ccc");
        }
        if (collider.tag == "Player" && lv >= 1)
        {

            Flowchart.BroadcastFungusMessage("end");
        }

    }

    void fungusopen()
    {
        SelectionManager.FungusOn = true;
    }

    public void fungusfinish()
    {
        PlayerPrefs.SetInt("LV", 1);
        Destroy(this.gameObject);
        SelectionManager.FungusOn = false;
    }
}
