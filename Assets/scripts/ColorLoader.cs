using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ColorCostume;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorCostume = GetComponentInParent<Playermovement>().Colortopass;
    }
}
