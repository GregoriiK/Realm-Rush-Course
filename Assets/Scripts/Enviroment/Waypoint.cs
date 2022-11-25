using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isPlaceable)
        {
            bool isPlaced = towerPrefab.PlaceTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
