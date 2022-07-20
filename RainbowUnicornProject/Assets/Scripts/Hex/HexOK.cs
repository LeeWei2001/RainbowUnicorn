using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class HexOK : MonoBehaviour
{
    [SerializeField]
    private GlowHighlight highlight;
    private HexCoordinates hexCoordinates;

    public bool lightUP; 

    public Vector3Int HexCoords => hexCoordinates.GetHexCoords();

    private void Awake()
    {
        hexCoordinates = GetComponent<HexCoordinates>();
        highlight = GetComponent<GlowHighlight>();
    }

    public void EnableHighlight()
    {
        highlight.ToggleGlow(true);

        lightUP = true;
    }

    public void DisableHighlight()
    {
        highlight.ToggleGlow(false);

        lightUP = false;
    }

}
