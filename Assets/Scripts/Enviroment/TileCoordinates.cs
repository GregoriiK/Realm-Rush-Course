using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class TileCoordinates : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.gray;
    [SerializeField] Color blockedColor = Color.red;

    TextMeshPro label;
    Vector2Int coordinate = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponentInChildren<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
        }
        SetColorLabel();
        ToggleLabel();
    }

    void SetColorLabel()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {   
            label.enabled = !label.enabled;
        }
    }

    void DisplayCoordinates()
    {
        coordinate.x = Mathf.RoundToInt(gameObject.transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinate.y = Mathf.RoundToInt(gameObject.transform.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinate.x}, {coordinate.y}";

        gameObject.name = coordinate.ToString(); //changing name of tile to its coordinates
        
    }
}
