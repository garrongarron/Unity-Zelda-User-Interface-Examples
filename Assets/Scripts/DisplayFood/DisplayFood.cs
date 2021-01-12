using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFood : MonoBehaviour
{
    public int status = 0;
    public float Duration;
    public bool mFaded = false;
    CanvasGroup canvGroup;
    RectTransform myRectTransform;
    Vector3 origin;
    public float height;
    public float width;

    void Awake(){
        canvGroup = GetComponent<CanvasGroup>();
        canvGroup.alpha = 0f;
        myRectTransform = GetComponent<RectTransform>();
        origin = myRectTransform.localPosition;
        width = myRectTransform.sizeDelta.x;
        myRectTransform.localPosition = new Vector3(origin.x + width, origin.y, origin.z);
    }

    public void SetOrigin(Vector3 v3){
        origin = v3;
    }

   public float GetWidth(){
       return width;
   }

    void Fade()
    {
        StartCoroutine(DoFade(canvGroup,canvGroup.alpha, mFaded?1:0));
        mFaded = !mFaded;
    }

    void FadeIn(){
        StartCoroutine(DoFade(canvGroup,canvGroup.alpha, 1f));
        
    }
    void FadeOut(){
        StartCoroutine(DoFade(canvGroup,canvGroup.alpha, 0f));
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while(counter < Duration)
        {
            counter += Time.deltaTime;
            if(end ==1f){
                myRectTransform.localPosition = Vector3.Lerp(myRectTransform.localPosition,origin, counter/Duration);
            }
            canvGroup.alpha = Mathf.Lerp(start, end, counter/Duration);
            yield return null;
        }
    }

    public void Next(){
        Exec();
        status++;
    }

    void Exec(){
        if(status == 0){
            FadeIn();
            StartCoroutine(TimeOut());
        }
        if(status == 1){
            StartCoroutine(Show1());
        }
        if(status == 2){
            StartCoroutine(Show2());
        }
        if(status == 3){
            FadeOut();
        }
        if(status >= 4){
            Destroy(this.gameObject);
        }
    }

    public IEnumerator Show1()
    {
        while(myRectTransform.localPosition.y > origin.y-height)
        {
            myRectTransform.localPosition -= 3 * Vector3.up * (height*Time.deltaTime)/Duration;
            yield return null;
        }
    }
    public IEnumerator Show2()
    {
        while(myRectTransform.localPosition.y > origin.y-height*2)
        {
            myRectTransform.localPosition -= 3 * Vector3.up * (height*Time.deltaTime)/Duration;
            yield return null;
        }
    }

    public IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(3f);
        FadeOut();
    }

    
}
