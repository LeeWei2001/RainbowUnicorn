using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playingstage : MonoBehaviour
{

    public bool move;
    public Transform car;
    
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            move = true;
            Cursor.lockState = CursorLockMode.Confined;
            //Cursor.visible = false;
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;

        }
        else
        {
            move = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (move == true)
        {
            
        }
        else
        {
            

        }


    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "playingarea")
        {

            Destroy(this.gameObject);
        }
        
    }
    void OnMouseOver()
    { 
       if(move == true)
        {

            Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);

        }
    }

   
}
