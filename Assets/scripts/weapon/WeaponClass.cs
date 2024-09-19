using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// alright this thing might get scrapped in the end
// or not because using entities for everything is way more efficient than prefabing everything
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapondata", order = 1)]
public class WeaponClass : ScriptableObject
{
    public int itemId; //set the weapon to an ID, could be useful but i'm honestly not sure it will be used

    public string tags; //not used currently but imagine setting a spawner to only spawn items with tag sword or with the tag gun

    public bool playerAffiliate; //check for things like grenades, i.e this basically makes it so even if the player was the one who used the weapon he can still be hit

    public GameObject affiliation; //check for things like the current object wielder

    public GameObject objectResource; //the item itself being spawned

    public bool debugItem; //basically do not spawn if item is debug unless stated, this basically allows for creating weapons for debugging purposes without it impacting gameplay

}