using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickaxeforce : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 _AddedForce;
    public AudioClip PickSound;
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(_AddedForce.x * GetComponent<Bullet>().bullet_dir, _AddedForce.y));
        GetComponent<AudioSource>().PlayOneShot(PickSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
