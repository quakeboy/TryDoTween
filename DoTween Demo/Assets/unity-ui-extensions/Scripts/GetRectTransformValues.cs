using UnityEngine;
using System.Collections;

public class GetRectTransformValues : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        var RT = GetComponent<RectTransform>();
        Debug.Log("Anchor Min: " + RT.anchorMin);
        Debug.Log("Anchor Max: " + RT.anchorMax);
        Debug.Log("Anchor Pos: " + RT.anchoredPosition);
        Debug.Log("Size Delta: " + RT.sizeDelta);
    }
}
