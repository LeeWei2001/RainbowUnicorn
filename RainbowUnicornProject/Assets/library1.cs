using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class library1 : MonoBehaviour
{
    private List<GameObject> CardsInHand = new List<GameObject>();
    public SameDistanceChildren slots;



    void Start()

    {

        

    }
    void Update()
    {
        foreach (GameObject g in CardsInHand)
        {
            // tween this card to a new Slot
            g.transform.DOLocalMoveX(slots.Children[CardsInHand.IndexOf(g)].transform.localPosition.x, 0.3f);

            // apply correct sorting order and HandSlot value for later 
            WhereIsTheCardOrCreature w = g.GetComponent<WhereIsTheCardOrCreature>();
            w.Slot = CardsInHand.IndexOf(g);
            w.SetHandSortingOrder();
        }
    }









}
