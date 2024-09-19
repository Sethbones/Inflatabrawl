using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public int AmountOfBucketCharges;
    public int ActualCharges;
    public bool playbucketanim = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (AmountOfBucketCharges >= 1)
        {
            GetComponent<Animator>().Play("BucketIdleCharge");
        }
        ActualCharges = AmountOfBucketCharges;


    }

    void CustomFire() //canned
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("gunshoot") || GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BulletFire"))
        {
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BulletFire") && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0)
            {
                GetComponent<Animator>().Play("gunshoot");
            }
        }
        else
        {
            GetComponent<Animator>().Play("gunshoot");
        }
    }
}
