using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCollision : MonoBehaviour
{
    [SerializeField ]private float _ExplosionDuration;
    // Start is called before the first frame update
    public AudioClip ExplosionSound;

    private void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(ExplosionSound);
    }
    private void Update()
    {
        _ExplosionDuration -= 200f * Time.deltaTime;

        if (_ExplosionDuration <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
