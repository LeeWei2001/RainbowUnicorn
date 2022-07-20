using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;



public class cardmovetxt : MonoBehaviour
{

    public static GameObject del;
    public static int point;
    public float scale;
    public static bool CardUse = false;
    public bool a;
    public bool c = true;
    public GameObject carddig;
    public bool UsePointerDisplacement = true;
    // PRIVATE FIELDS
    // a reference to a DraggingActionsTest script
    private DraggingActionsTest da;
    // a flag to know if we are currently dragging this GameObject
    private bool dragging = false;
    // distance from the center of this Game Object to the point where we clicked to start dragging 
    private Vector3 pointerDisplacement = Vector3.zero;
    // distance from camera to mouse on Z axis 
    private float zDisplacement;
    void Start()
    {
       
    }

    void Awake()
    {
        da = GetComponent<DraggingActionsTest>();
        c = true;
    }
    void OnMouseDown()
    {
        //this.gameObject.transform.localScale += new Vector3(-scale / 2, -scale, 0);
        a = true;
        carddig.SetActive(false);
        if (da.CanDrag)
        {
            dragging = true;
            HoverPreview.PreviewsAllowed = false;       // NEW LINE
            da.OnStartDrag();
            zDisplacement = -Camera.main.transform.position.z + transform.position.z;
            if (UsePointerDisplacement)
                pointerDisplacement = -transform.position + MouseInWorldCoords();
            else
                pointerDisplacement = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = library.i;
        if (dragging)
        {
            Vector3 mousePos = MouseInWorldCoords();
            da.OnDraggingInUpdate();
            //Debug.Log(mousePos);
            transform.position = new Vector3(mousePos.x - pointerDisplacement.x, mousePos.y - pointerDisplacement.y, transform.position.z);
        }
    }

    void OnMouseUp()
    {
        a = false;
        if (dragging)
        {        
            dragging = false;
            HoverPreview.PreviewsAllowed = true;   // NEW LINE
            da.OnEndDrag();  
        }
    }

    // returns mouse position in World coordinates for our GameObject to follow. 
    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        //Debug.Log(screenMousePos);
        screenMousePos.z = zDisplacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }
    void OnTriggerStay(Collider collision)
    {
        if (dragging != true)
        {
            if (collision.tag == "playingarea" && collision.name == "SlimeBattle")
            {
                //CardUse = true;
                GameObject.Find("UI").SendMessage("RemoveCardFromHand");
                GameObject.Find("SlimeBattle").GetComponent<EnemySlime>().CardUse(); //能調用public和private類型函數
                library.i -= 1;
                Destroy(this.gameObject);
            }

            if (collision.tag == "playingarea" && collision.name == "DogBattle")
            {
                //CardUse = true;
                GameObject.Find("UI").SendMessage("RemoveCardFromHand");
                GameObject.Find("DogBattle").GetComponent<EnemyDog>().CardUse(); //能調用public和private類型函數
                library.i -= 1;
                Destroy(this.gameObject);
            }

            if (collision.tag == "playingarea" && collision.name == "SlimeDogBattle")
            {
                //CardUse = true;
                GameObject.Find("UI").SendMessage("RemoveCardFromHand");
                GameObject.Find("SlimeDogBattle").GetComponent<EnemySlimeDog>().CardUse(); //能調用public和private類型函數
                library.i -= 1;
                Destroy(this.gameObject);
            }

            if (collision.name == "Player")
            {
                GameObject.Find("UI").SendMessage("RemoveCardFromHand");
                library.i -= 1;
                GameObject.Find("Player").GetComponent<PlayerCardBattle>().CardEffect();
                Destroy(this.gameObject);
            }
        }

    }
    void OnMouseExit()
    {
        if (a == false)
        {
            carddig.SetActive(false);
        }
    }
    void OnMouseEnter()
    {
        del = this.gameObject;

        if (a==false)
        {
            carddig.SetActive(true);
        }
    }
    
}


