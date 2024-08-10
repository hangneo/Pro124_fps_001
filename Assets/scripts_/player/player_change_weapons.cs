using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_change_weapons : MonoBehaviour
{
    float timer, timez;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform fire_point;
    [SerializeField] bool can_fire = true;
    [SerializeField] float time_between, defaultTimeBetween;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!can_fire)
        {
            timer += Time.deltaTime;
            if (timer > time_between)
            {
                can_fire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && can_fire)
        {
            can_fire = false;
            fire();
        }
    }

    void fire()
    {
        var bullet_speed = Instantiate(bullet, fire_point.position, fire_point.rotation);
        game_manager.instance.play_sfx("gun_1");
    }

    public void tang_toc_do_ban(int sp, float x)
    {
        defaultTimeBetween = time_between;
        time_between = sp;
        timez = x;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(timez);
        time_between = defaultTimeBetween;
    }   
}
