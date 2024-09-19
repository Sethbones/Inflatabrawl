using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueCalamity : MonoBehaviour
{
    public GameObject ShardA;
    public GameObject ShardB;
    public GameObject ShardC;
    public GameObject ShardD;
    public AudioClip CreateSound;

    public void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(CreateSound);
    }

    private void OnDestroy()
    {
        var splitA = Instantiate(ShardA, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitA.GetComponent<Rigidbody2D>().AddForce(new Vector2(80, 150));
        var splitB = Instantiate(ShardB, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitB.GetComponent<Rigidbody2D>().AddForce(new Vector2(-80, 150));
        var splitC = Instantiate(ShardC, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitC.GetComponent<Rigidbody2D>().AddForce(new Vector2(40, 150));
        var splitD = Instantiate(ShardD, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), transform.rotation);
        splitD.GetComponent<Rigidbody2D>().AddForce(new Vector2(40, 150));
    }
}
