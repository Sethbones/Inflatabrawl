using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WeaponCollision : MonoBehaviour
{
    public enum PlayerStates
    {//all of these are identical to the player's animations becuase they need to sync up 
        idle, //the character's default animation when not doing anything
        move, //the character moving on the ground
        jump, //the character jumping
        fall, //the animation that plays after jumping. might get scrapped in favor of making the jump animation stupid long but then again it could be bad when it comes to making weapons
        fire, //gun shoot animation
        charge //charge weapons go brrr
    }
    public GameObject bulletprefab; //the projectile of the weapon
    public bool canCollide = true; //check if the player equipped weapon or not. name might change
    public GameObject affiliation; //to what object does this belong to
    public bool _CanShoot = true; //check if the projectile can shoot
    public static float _TimeBetweenShots = 125f; //amount of time in frames it takes for it to shoot
    public float _TimeDownBetweenShots; //the actual countdown //would probably better off as a local variable
    public float _ChargeTime; //the amount of time needed to be charged
    public bool _ChargeWeapon; //if the weapon need to be charged first
    public float _AmmoCount; //mostly for things like bananas or something, there's has to be something with limited ammo
    public bool _SingleUse = false; //remove item from parent player on use
    public bool _HasRecoil = false; //applies knockback on shoot
    public Vector3 offset = new Vector3(0,0,0); //the offset of the weapon on the player
    public Vector3 bulletoffset = new Vector3(0,0,0); //the offset location the projectile spawns
    public bool IsMelee; //essentially if its a melee weapon it creates the projetile as a child of the player instead of the scene
    public AudioClip ShootSound;
    public AudioClip CollectSound;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.parent.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().Play("gunidle");
            GetComponent<AudioSource>().PlayOneShot(CollectSound);
        }
    }

    // Update is called once per frame
    void Update()
    {//this part should probably be moved to its own script but time will tell
        if (!canCollide){//i do not remember why i put this here so uhhhhhhh wait for code cleanup i guess
                transform.parent.GetComponentInParent<Playermovement>().EquippedWeapon = gameObject; //the only thing this does is allow access to this object from the player movement script, because i hate using getcomponentinchildren 
        }
        //Debug.Log(GetComponentInParent<Transform>().transform.localScale.x);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Playermovement>().equipped == false)
            {
                if (canCollide)
                {
                    Debug.Log(message: "weapon collected");
                    GetComponent<Collider2D>().enabled = false;
                    canCollide = false;
                    Instantiate(gameObject, new Vector3(collision.transform.Find("WeaponContainer").position.x + offset.x * collision.transform.localScale.x, collision.transform.Find("WeaponContainer").position.y + offset.y, 1), collision.transform.rotation, collision.transform.Find("WeaponContainer"));
                    collision.gameObject.GetComponent<Playermovement>().equipped = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    public void bulletshoot() //gun pre shoot animation
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
    public void WeaponDrop() //drop gun
    {
        Destroy(gameObject);
    }
    public void FireBullet(string message) //fires the actual bullet (Timing controlled by the animation itself)
    {
        if (message.Equals("shoot"))
        {
            if (IsMelee)
            {
                var meleehitbox = Instantiate(bulletprefab, new Vector3(transform.position.x + bulletoffset.x * transform.parent.parent.localScale.x, transform.position.y + bulletoffset.y, transform.position.z), transform.rotation, transform);
                meleehitbox.GetComponent<Bullet>()._affiliation = transform.parent.parent.gameObject;
                meleehitbox.GetComponent<Bullet>().bullet_dir = transform.parent.parent.localScale.x;
            }
            else
            {
                var bullet = Instantiate(bulletprefab, new Vector3(transform.position.x + bulletoffset.x * transform.parent.parent.localScale.x, transform.position.y + bulletoffset.y, transform.position.z), transform.rotation);
                bullet.GetComponent<Bullet>()._affiliation = transform.parent.parent.gameObject;
                bullet.GetComponent<Bullet>().bullet_dir = transform.parent.parent.localScale.x;
                if (_SingleUse)
                {
                    Destroy(gameObject);
                    transform.parent.parent.GetComponent<Playermovement>().equipped = false;
                }
            }
        }
        GetComponent<AudioSource>().PlayOneShot(ShootSound);
    }
}
