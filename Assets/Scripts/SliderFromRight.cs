using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderFromRight : MonoBehaviour
{
    public float time;
    bool visible = true;
    bool hide = true;
    bool ok = false;
    Vector3 origin;
    RectTransform myRectTransform;
    private float width;

    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
        origin = myRectTransform.localPosition;
        width = myRectTransform.sizeDelta.x;
        myRectTransform.localPosition = new Vector3(origin.x + width, origin.y, origin.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ok = !ok;
            if(ok){
                visible = false;
            } else {
                hide = false;
            }
        }
        Show();
        Hide();
    }

    void Show()
    {
        if (!visible)
        {
            myRectTransform.localPosition -= Vector3.right * (width*Time.deltaTime)/time;
            if (myRectTransform.localPosition.x < origin.x)
            {
                visible = true;
                myRectTransform.localPosition = origin;
            }
        }
    }
    
    void Hide()
    {
        if (!hide)
        {
            myRectTransform.localPosition += Vector3.right * (width*Time.deltaTime)/time;
            if (origin.x + width < myRectTransform.localPosition.x)
            {
                hide = true;
                myRectTransform.localPosition = origin+Vector3.right*width;
            }
        }
    }
}
