using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{
    public GameObject weapon_opject;
    public Sprite weapon_sprite;
    public int min_damage, max_damage;
    public AudioClip clips;

    public int take_damage()
    {
        return Random.Range(min_damage, max_damage);            
    }
}
