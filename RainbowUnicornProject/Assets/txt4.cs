using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class txt4 : MonoBehaviour
{
    public BoxCollider trigger;
    // Start is called before the first frame update
    void Start()
    {
        trigger = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        Invoke("fungusopen", 0.5f);
        if (collider.tag == "Player")
        {

            Flowchart.BroadcastFungusMessage("bbb");
        }
    }

    void fungusopen()
    {
        SelectionManager.FungusOn = true;
    }

    public void fungusfinish()
    {
        PlayerPrefs.DeleteKey("LV");
        Destroy(trigger);
        SelectionManager.FungusOn = false;
    }
}
