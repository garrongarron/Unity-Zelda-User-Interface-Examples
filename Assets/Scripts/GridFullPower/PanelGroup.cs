using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelGroup : MonoBehaviour
{
    public Transform buttons;
    private int panelIndex = 0;
    private int panelsLength;
    void Awake(){
        panelsLength = transform.childCount;
        if(panelsLength == 0){
            Debug.Log("No Panels");
            return;
        }
        ShowCurrentPanel();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            panelIndex++;
            if(panelIndex >buttons.childCount-1){
                // panelIndex = 0;
                panelIndex--;
            } else {
                buttons.GetChild(panelIndex).GetComponent<TabButton>().Activate();
                SetPageIndex(panelIndex);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            panelIndex--;
            if(panelIndex < 0){
                // panelIndex = buttons.childCount-1;
                panelIndex++; return;
            } else {
                buttons.GetChild(panelIndex).GetComponent<TabButton>().Activate();
                SetPageIndex(panelIndex);
            }
                
        }
    }

    void ShowCurrentPanel(){
        for (int i = 0; i < panelsLength; i++)
        {
            
            if(panelIndex == i){
                transform.GetChild(i).gameObject.SetActive(true);
            } else {
                transform.GetChild(i).gameObject.SetActive(false);
                buttons.GetChild(i).gameObject.GetComponent<TabButton>().Deactivate();
            }
        }
    }
    
    public void SetPageIndex(int n){
        panelIndex = n;
        ShowCurrentPanel();
    }
}
