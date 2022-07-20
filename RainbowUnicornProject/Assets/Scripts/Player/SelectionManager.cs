using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static bool FungusOn;

    [SerializeField]
    private Camera mainCamera;

    //public GameObject Ujump;

    public Vector3 Ujump;

    public LayerMask selectionMask;

    public HexGrid hexGrid;

    public GameObject Horse;

    public float movespeed;

    bool start;

    Vector3 targetPosition;

    List<Vector3Int> neighbours = new List<Vector3Int>();

    public void Start()
    {
        //Horse = GameObject.Find("Player");
    }

    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

    }

    public void Update()
    {
            if (Horse == null)
                Horse = GameObject.Find("PlayerMove");
            if (start == true && FungusOn == false)
            {
                if (FungusOn == false)
                    Horse.transform.position = Vector3.MoveTowards(Horse.transform.position, targetPosition, movespeed);
                /*Horse.transform.rotation = */
            }

        if (Input.GetKeyDown(KeyCode.U))
        {
            
            Horse.transform.position = Ujump;
        }
    }
        


    public void HandleClick(Vector3 mousePosition )
    {
        GameObject result;
        if(FindTarget(mousePosition, out result) && FungusOn == false)
        {
            HexOK selectedHex = result.GetComponent<HexOK>();
            selectedHex.DisableHighlight();            
            targetPosition = selectedHex.transform.position;
            targetPosition.y += 1.5f;
            start = true;

            /*if (targetPosition.x - Horse.transform.position.x > 0)
            {

            }
            if(targetPosition.y - Horse.transform.position.y > 0)
            {

            }
            if (targetPosition.z - Horse.transform.position.z > 0)
            {

            }
            if (targetPosition.x - Horse.transform.position.x < 0)
            {

            }
            if (targetPosition.y - Horse.transform.position.y < 0)
            {

            }
            if (targetPosition.z - Horse.transform.position.z < 0)
            {

            }*/

            //Horse.transform.rotation =



            /*Horse.transform.position = targetPosition;*/



            foreach (Vector3Int neighbour in neighbours)
            {
                hexGrid.GetTileAt(neighbour).DisableHighlight();
            }

            neighbours = hexGrid.GetNeighboursFor(selectedHex.HexCoords);

            foreach (Vector3Int neighbour in neighbours)
            {
                hexGrid.GetTileAt(neighbour).EnableHighlight();
            }

            Debug.Log($"Neighbours for {selectedHex.HexCoords} are:");

            foreach (Vector3Int neighbourPos in neighbours)
            {
                Debug.Log(neighbourPos);
            }

            
        }
    }

    private bool FindTarget(Vector3 mousePosition, out GameObject result)
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if(Physics.Raycast(ray, out hit , selectionMask))
        {
            result = hit.collider.gameObject;
            return true;
        }
        result = null;
        return false;
    } 
}
