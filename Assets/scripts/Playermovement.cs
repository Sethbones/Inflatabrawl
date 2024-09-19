using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEngine.InputSystem.InputAction;

public class Playermovement : MonoBehaviour
{
    public enum PlayerStates
    {//if and when code cleanup comes this will make more sense
        revival, //plays for one frame when the character respawns
        intro, //plays on match start. might get removed in favor of a fancy transition into the level scene instead
        idle, //the character's default animation when not doing anything
        move, //the character moving on the ground
        jump, //the character jumping
        fall,//the animation that plays after jumping. might get scrapped in favor of making the jump animation stupid long but then again it could be bad when it comes to making weapons
        death //the player's death animastion afterwards plays revival //currently unimplemented
    }

    [SerializeField] private float MOVE_SPEED = 50f; //movement speed
    [SerializeField] private float JUMP_FORCE = 195f; //Jump Height
    //private float GRAVITY = 15f; //when the movement get rewritten it might be used
    //private float MAX_FALL_SPEED = 200; //when the movement get rewritten it might be used
    public float move_dir; //the direction the player is supposed to be moving in
    [SerializeField] private bool grounded = true; //check if the player is grounded
    public float xvelocity; //check velocity, is for debugging
    public float yvelocity; //check velocity, is for debugging
    [SerializeField] private bool can_jump = true; //check if the player is both grounded and can jump
    public bool equipped = false; //check if weapon is equipped
    public int _PlayerID = 1; //get the player's current ID, meant for multiplayer although i'm still not sure how to get expandable amount of characters
    //playerID is not to be assigned directly (unless debugging) and instead takes it's value from the menus and is then assigned to a global variable where its kept till its called
    public GameObject _HatPrefab; //the prefab of the hat
    public GameObject _SkinPrefab; //the prefab of the player color
    public GameObject _EyePrefab; //the prefab of the player eye type
    public float movepos = 1; //for the bullet, static last direction moved //could be potentially be worked around by having the bullet fire by the player's Xscale
    public bool _CanMove = true; //for match start and death animations check if the player can move
    public bool _Invincible = false; //respawn invincibilt, 
    public float _InvincibilityDownTimer; //the ticking invincibility timer
    public const float _InvincibilityTimer = 250; //to keep the timer value static instead of manually setting it every time through code
    public int _PlayerLives = 1; //if at 0 destroy player
    public GameObject _RespawnPoint; //not to be set directly, its set automatically the player spawner 
    public bool isdead = false; //check if the player died to play the death animation
    public bool _IsGravityFlipped = false; //soon ish
    public Vector2 input_vector;
    public PlayerInput _InheritedInput;
    public GameObject EquippedWeapon;


    //costume stuff because getcomponentinchildren is stupid and requires a for loop, i could not be assed i'll be real here
    public GameObject Colortopass; //needs to be changed to spriterenderer
    public GameObject eyetopass;
    public GameObject hattopass;

    //menu related BS, i have no idea how to do proper menu movements per player (and nor can i find anything relating to such a thing so this will suffice
    public bool inmenu = false;
    public GameObject UIArrows;

    //menu related things
    private PlayerConfiguration PlayerConfig;
    private Basic2DProject controls;

    public List<Transform> targettest;

    public GameObject ColorObject;
    public GameObject EyeObject;
    public GameObject HatObject;


    //sounds and shit
    public AudioClip JumpSound;
    public AudioClip LandSound;

    //death effect
    [SerializeField] private GameObject PopEffect;


    //Start is called before the first frame update
    void Awake()
    {
        GlobalVars.instance.StaticTargets.Add(transform);
        controls = new Basic2DProject();
        //DontDestroyOnLoad(this.gameObject); //legacy shit
        //var playeranim = this.gameObject.transform.GetChild(0).gameObject<Animator>();
    }
    public void InitializePlayer(PlayerConfiguration config)
    {
        PlayerConfig = config;
        ColorObject.GetComponent<SpriteRenderer>().sprite = config.playercolor;
        EyeObject.GetComponent<SpriteRenderer>().sprite = config.playereyes;
        HatObject.GetComponent<SpriteRenderer>().sprite = config.playerhat;
        config.Input.onActionTriggered += Input_onActionTriggered;
    }
    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Player.Move.name)//.Move.name)
        {
            OnMove(obj);
        }
        if (obj.action.name == controls.Player.Jump.name)//.Move.name)
        {
            OnJump(obj);
        }
        if (obj.action.name == controls.Player.Fire.name)//.Move.name)
        {
            OnFire(obj);
        }
        if (obj.action.name == controls.Player.DropWeapon.name)//.Move.name)
        {
            OnDropWeapon(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inmenu)
        {

        }
        else
        {
           //suckmassivecock;
        }
        xvelocity = GetComponent<Rigidbody2D>().velocity.x;
        yvelocity = GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Animator>().SetFloat("Xvelocity", Mathf.Abs(xvelocity * -1));
        GetComponent<Animator>().SetBool("grounded", can_jump);
        GetComponent<Animator>().SetBool("weaponwield", equipped);

        //left right movement
        //yeah there's most definitely
        if (_PlayerID == 1)
        {
            ////Debug.Log(message: "fuck1");
            //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            //{
            //    move_dir = 1; //this is so when a character isn't moving the velocity is applying a multiplier of 0
            //    transform.localScale = new Vector3(move_dir, 1, 1); //rotates character based on the move_dir value
            //    movepos = 1;
            //}
            //else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            //{
            //    move_dir = -1;
            //    transform.localScale = new Vector3(move_dir, 1, 1);
            //    movepos = -1;
            //}
            //else { move_dir = 0; }

            //jumping //legacy Sc
            //if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
            //{
            //    if (can_jump) //grounded && can_jump
            //    {
            //        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JUMP_FORCE);
            //        grounded = false;
            //        can_jump = false;
            //    }
            //}
        }

        //misc
        if (grounded) //ground check
        {
            if (yvelocity == 0) //if the character is flat on a surface
            {
                can_jump = true;
            }
            else if (yvelocity != 0)
            {
                can_jump = false;
            }

        }
        if (input_vector.x != 0) {
            transform.localScale = new Vector3(input_vector.x, 1, 1);
        }
    }
    void FixedUpdate()
    {
        //OnMove();
        GetComponent<Rigidbody2D>().velocity = new Vector2(input_vector.x * MOVE_SPEED, GetComponent<Rigidbody2D>().velocity.y);
    }

    //Check if Grounded
    void OnCollisionEnter2D(Collision2D other)
    {//now as is if you hit a ceiling this check will go off, and technically there are 2 good options for solving this: a raycast to check under the player, or you can assign a tag to the collision point 
        {
            if (other.gameObject.CompareTag("Ground")) //checks if on a tile with a ground collision tag
            {
                grounded = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (equipped == false)
            {
                //Instantiate(collision.gameObject, gameObject.transform, false);
                //equipped = true;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Space")) //checks if on a tile with a ground collision tag
        {
            can_jump = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Space")) //checks if on a tile with a ground collision tag
        {
            can_jump = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
    //new movement --UNORGANIZED--
    void OnMove(CallbackContext value) //despite onMove Working it has no idea visual studio reads it as if its a nothing input
    {
        input_vector = value.ReadValue<Vector2>();
        Debug.Log(message: "move");
        //Debug.Log(value.Get<Vector2>());
    }

    void OnJump(CallbackContext value) //despite onMove Working it has no idea visual studio reads it as if its a nothing input
    { 
        if (value.performed)
        {
            if (can_jump) //grounded && can_jump
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JUMP_FORCE);
                grounded = false;
                can_jump = false;
                GetComponent<AudioSource>().PlayOneShot(JumpSound);
            }
        }
        
    }

    void OnFire(CallbackContext value) //despite onMove Working it has no idea visual studio reads it as if its a nothing input
    {
        if (value.performed)
        {
            EquippedWeapon.GetComponent<WeaponCollision>().bulletshoot();
        }
    }

    void OnDropWeapon(CallbackContext value) //despite onMove Working it has no idea visual studio reads it as if its a nothing input
    {
        if (value.performed)
        {
            EquippedWeapon.GetComponent<WeaponCollision>().WeaponDrop();
            equipped = false;
        }
    }
    private void OnDestroy()
    {
        Instantiate(PopEffect, transform.position, transform.rotation);
        GlobalVars.instance.StaticTargets.Remove(transform);
        Debug.Log("fickle");
    }
}