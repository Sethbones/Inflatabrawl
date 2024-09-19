using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPop : MonoBehaviour
{
    [SerializeField] private AudioClip BalloonPopSound;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float shakeduration = 1f;
    [SerializeField] private float Strength = 1f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(BalloonPopSound);
        //StartCoroutine(Shaking());
    }

    ////note to self unity cannot shake a moving camera
    //IEnumerator Shaking()
    //{
    //    Vector3 startPosition = FindObjectOfType<Camera>().transform.position;
    //    float elapsedTime = 0f;
    //    while (elapsedTime < shakeduration)
    //    { 
    //        elapsedTime += Time.deltaTime;
    //        //float strength = 1f;//curve.Evaluate(elapsedTime / shakeduration);
    //        FindObjectOfType<Camera>().transform.position = startPosition + Random.insideUnitSphere * Strength;
    //        yield return null;
    //    }

    //    transform.position = FindObjectOfType<Camera>().transform.position;
    //}
}
