using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBoom : MonoBehaviour
{
    public float grenadetimer;
    public GameObject explosionprefab;
    public Vector2 grenadestrength;
    public AudioClip GrenadeToss;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(grenadestrength.x * GetComponent<Bullet>().bullet_dir, grenadestrength.y));
        GetComponent<AudioSource>().PlayOneShot(GrenadeToss);
    }

    // Update is called once per frame
    void Update()
    {
        grenadetimer -= 200f * Time.deltaTime;

        if (grenadetimer <=0)
        {
            Instantiate(explosionprefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
