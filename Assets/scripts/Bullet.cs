using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject _affiliation; //check who it belongs to, set by the weapon itself
    public bool ishitvalid = true;
    public float bullet_dir = 1; //inherits movepos from player to shoot in the desired direction
    public float _projectileLifespan; //set to like 4-12 for melee weapons depending on what you need //set to -1 if a weapon has no need to vanish, i.e throwables
    public bool _RemoveAtMapEdge = true; //this is specific to melee weapons although will probably be deleted eventually
    public bool _RemoveOnCollide = true; //remove when interacting with collision
    public float _BulletSpeed; //how fast the bullet moves, set to 0 for melee hitboxes
    public bool _KillOnHit = true; //this is to dictate if a weapon should kill the target or just do something on a hit with a seperate script 
    public bool applyvelocity = true; //this just so i can block that part of the script
    public bool _nolifespan = false;
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(bullet_dir, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (applyvelocity)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(_BulletSpeed * bullet_dir, GetComponent<Rigidbody2D>().velocity.y);
        }
        //Debug.Log(_affiliation);
        if (!_nolifespan)
        {
            if (_projectileLifespan != 0) { _projectileLifespan -= Time.deltaTime * 200f; }
            if (_projectileLifespan <= 0)
            {
                Destroy(gameObject);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject == _affiliation)
            {
                ishitvalid = false;
            }
            else { ishitvalid = true; } //check if i shit valid

            if (ishitvalid && collision.gameObject.CompareTag("Player"))
            {
                if (_KillOnHit)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
        if (_RemoveOnCollide)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ceiling") || collision.gameObject.CompareTag("Slope Top") || collision.gameObject.CompareTag("Slope Bottom"))
            {
                Destroy(gameObject);
            }
        }
        if (_RemoveAtMapEdge) //there has to be a use for this at some point
        {
            if (collision.gameObject.CompareTag("MapExtents"))
            {
                Destroy(gameObject);
            }
        }
    }
}
