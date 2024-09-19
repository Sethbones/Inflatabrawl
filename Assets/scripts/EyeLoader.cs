using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EyeCostume;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EyeCostume = GetComponentInParent<Playermovement>().eyetopass;
    }
}
