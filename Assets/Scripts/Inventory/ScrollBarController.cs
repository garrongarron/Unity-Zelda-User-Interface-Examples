using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour
{
    [Header("Variables a rellenar")]
    public int totalLevels;
    public Scrollbar scrollBar;
    void Start()
    {
        scrollBar.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
