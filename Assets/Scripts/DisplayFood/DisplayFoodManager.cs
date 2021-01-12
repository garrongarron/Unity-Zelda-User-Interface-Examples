using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFoodManager : MonoBehaviour
{
    public GameObject myPrefab;
    private List<GameObject> list = new List<GameObject>();
    int index = 0;
    string str;

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Q)){
            GameObject go = Instantiate(myPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(this.transform);
            go.GetComponent<Transform>().localScale = Vector3.one;
            float w = go.GetComponent<DisplayFood>().GetWidth();
            go.GetComponent<Transform>().localPosition = new Vector3(w/2, 50f, 0f);
            go.GetComponent<DisplayFood>().SetOrigin(new Vector3(-w/2, 50f, 0f));
            DeleteObjects();
        }
    }
    void DeleteObjects(){
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<DisplayFood>().Next();
        } 
    }
    
   
}
