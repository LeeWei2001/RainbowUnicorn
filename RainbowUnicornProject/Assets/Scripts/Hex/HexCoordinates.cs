using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCoordinates : MonoBehaviour
{
    public static float xOffset = 2.87f, yOffset = 1, zOffset = 2.485f;

    [Header("Offset coordinates")]
    [SerializeField]
    private Vector3Int offsetCoordinates;

    internal Vector3Int GetHexCoords()
        => offsetCoordinates;

    private void Awake()
    {
        offsetCoordinates = ConvertPositionToOffset(transform.position);
    }

    private Vector3Int ConvertPositionToOffset(Vector3 position)
    {
        int x = Mathf.CeilToInt(position.x / xOffset);
        int y = Mathf.RoundToInt(position.y / yOffset);
        int z = Mathf.RoundToInt(position.z / zOffset);

        return new Vector3Int(x, y, z);
    }
}
