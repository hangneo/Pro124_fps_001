using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using static player_atk;
using static player_change_weapons;

public class player_atk : MonoBehaviour
{
    player_move pl_movez;
    Vector3 mouse_position;
    Vector2 rotation;
    float angle;
    Weapon current_weapon;
    [SerializeField] List<Weapon> weapons;

    void Start()
    {
        pl_movez = GetComponent<player_move>();

        current_weapon = weapons[0];
        SetWeaponActive(current_weapon, true);
    }

    void Update()
    {
        mouse_position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation = mouse_position - transform.position;
        angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        check_weapons();
    }

    void check_weapons()
    {
        if (current_weapon != null && current_weapon.weapon_opject.activeSelf)
        {
            var gun_sp = current_weapon.weapon_opject.GetComponent<SpriteRenderer>();

            if (gun_sp != null)
            {
                gun_sp.sprite = current_weapon.weapon_sprite;

                if (rotation.y > 0)
                {
                    if (rotation.x > 0) gun_sp.flipY = false;
                    if (rotation.x < 0) gun_sp.flipY = true;
                }
                else if (rotation.y < 0)
                {
                    if (rotation.x < 0) gun_sp.flipY = true;
                    if (rotation.x > 0) gun_sp.flipY = false;
                }
            }
        }
    }

    void SetWeaponActive(Weapon new_weapon, bool is_active)
    {
        if (new_weapon != null)
        {
            new_weapon.weapon_opject.SetActive(is_active);
        }
    }

    public void random_weapon()
    {
        var random_weapons = weapons[Random.Range(0, weapons.Count)];

        if (current_weapon == random_weapons)
        {
            return;
        }
        else if (current_weapon != null)
        {
            SetWeaponActive(current_weapon, false);

            current_weapon = random_weapons;
            SetWeaponActive(current_weapon, true);
        }
        else
        {
            return;
        }
    }    
}
