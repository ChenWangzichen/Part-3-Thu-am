using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject basket;
    public GameObject kettle;
    public GameObject bottle;
    public AnimationCurve animationCurve;
    float duration = 0f;
    float speed = 3f;
    float interpolation;
    Vector3 kettleE = new Vector3(0.58f,0,0);
    Vector3 bottleE = new Vector3(-0.48f,0,0);



    //Start is called before the first frame update
    void Start()
    {

        basket.transform.localScale = Vector3.zero;
        kettle.transform.localScale = Vector3.zero;
        bottle.transform.localScale = Vector3.zero;
        StartCoroutine(BuildIn());
        
        
    }

    void Update()
    {
        duration += Time.deltaTime * speed;
    }

    IEnumerator ScaleBasket()
    {
        while (basket.transform.localScale.x < 1)
        {
            interpolation = animationCurve.Evaluate(duration);
            basket.transform.localScale = Vector3.Lerp(Vector3.zero,Vector3.one, interpolation);
            yield return null;
        }
        duration = 0;

    }
    IEnumerator PutOutThings(GameObject thing, Vector3 end)
    {
        while(thing.transform.localScale.x < 1 && thing.transform.position != end)
        {
            interpolation = animationCurve.Evaluate(duration);
            thing.transform.position = Vector3.Lerp(Vector3.zero, end, interpolation);
            thing.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolation);
            yield return null;
        }
        duration = 0;
    }

    IEnumerator BuildIn()
    {
        yield return StartCoroutine(ScaleBasket());
        yield return StartCoroutine(PutOutThings(kettle, kettleE));
        yield return StartCoroutine(PutOutThings(bottle,bottleE));
    }
}
