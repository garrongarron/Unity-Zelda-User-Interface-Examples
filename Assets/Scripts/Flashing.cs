using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing : MonoBehaviour
{
    RectTransform rectTransform;
    public float speed = 8f;
    public float tiltAngle = 30.0F;
    public float n = 0f;
    private bool flag = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Delay());
        StartCoroutine(Appear(1f));
    }
    
    // Update is called once per frame
    void Update()
    {
        if(flag){
            n += 100*Time.deltaTime;
            Quaternion target = Quaternion.Euler(0, 0, n);
            rectTransform.transform.rotation = target;
        }
    }

    IEnumerator Delay(){
        flag = true;
        yield return new WaitForSeconds(2);
        flag = false;
    }
    
    public IEnumerator Appear(float time)
    {
        float counter = 0f;
        while(counter < time)
        {
            counter += Time.deltaTime;
            rectTransform.localScale = Vector3.one * counter;
            yield return null;
        }
        if(counter >= time){
            StartCoroutine(Disappear(1f));
        }
    }

    public IEnumerator Disappear(float time)
    {
        float counter = 0f;
        while(counter < time)
        {
            counter += Time.deltaTime;
            rectTransform.localScale = Vector3.one * (1f-counter);
            yield return null;
        }
        if(counter >= time){
            Destroy(this.gameObject);
        }
        
    }
}
