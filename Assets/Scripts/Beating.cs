using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beating : MonoBehaviour
{
    RectTransform rectTransform;
    int n = 0;
    Vector3 original;
    public float speed = 8f;
    public float intensity = 0.1f;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        original = rectTransform.localScale;
    }
    

    void Update()
    {
        rectTransform.localScale = original+ Vector3.one * Mathf.Sin(Time.time*speed) * intensity;
        // Debug.Log(1/Time.deltaTime);
    }
}
