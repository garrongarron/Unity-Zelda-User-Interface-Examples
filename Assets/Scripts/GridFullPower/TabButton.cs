
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
    private Image img;
    public int id;
    public PanelGroup panelGroup;
    void Awake() {
        img = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        panelGroup.SetPageIndex(id);
        Activate();
    }

    public void Activate(){
        img.color = new Color32(255,0,0,255);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(255,255,255,255);
    }

    public void Deactivate(){
        GetComponent<Image>().color = new Color32(255,255,255,255);
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color32(0,0,0,255);
    }
}