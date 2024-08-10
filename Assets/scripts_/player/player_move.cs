using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;



public class player_move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator ani;
    float speed, dash_time_, time;
    SpriteRenderer sp;
    public Vector2 move_;
    Coroutine coroutine_ghost;
    [SerializeField] float speed_basic = 8f, dash_boost, dash_time, ghost_delay, default_speed;
    [SerializeField] bool is_dashing;
    [SerializeField] GameObject ghost_dash;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        player_ani();

        speed = Math.Clamp(move_.magnitude, 0.0f, 1.0f);  

        if (Input.GetKeyDown(KeyCode.Space) && dash_time_ <= 0 && is_dashing == false)
        {
            speed_basic += dash_boost;
            dash_time_ = dash_time;
            is_dashing = true;
            start_ghost();
            game_manager.instance.play_sfx("dash");
        }
        
        if (dash_time_ <= 0 && is_dashing == true)
        {
            speed_basic -= dash_boost;
            is_dashing = false;
            stop_ghost();
        }
        else
        {
            dash_time_ -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = move_ * speed * speed_basic;
    }

    void OnMove(InputValue input)
    {
        move_ = input.Get<Vector2>();
    }

    void player_ani()
    {
        if (move_ != Vector2.zero)
        {
            ani.SetFloat("velocity.x", move_.x);
            ani.SetFloat("velocity.y", move_.y);
        }
        ani.SetFloat("speed", speed);       
    }

    void stop_ghost()
    {
        if (coroutine_ghost != null)
        {
            StopCoroutine(coroutine_ghost);
        }
    }

     public void start_ghost()
    {
        if (coroutine_ghost != null)
        {
            StopCoroutine(coroutine_ghost);
        }        
        coroutine_ghost = StartCoroutine(ghost_dash_());
    }

    IEnumerator ghost_dash_()
    {
        while (true)
        {
            if (move_.x < 0)
            {
                ghost_dash.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                ghost_dash.transform.localScale = new Vector3(1, 1, 1);
            }

            var ghost = Instantiate(ghost_dash, transform.position, transform.rotation);
            Sprite current_sp = sp.sprite;
            ghost.GetComponent<SpriteRenderer>().sprite = current_sp;

            Destroy(ghost, 0.5f);
            yield return new WaitForSeconds(ghost_delay);
        }
    }

    public void tang_speed(float sp, float time_)
    {
        default_speed = speed_basic;
        speed_basic = sp;
        time = time_;
        StartCoroutine(new_speed());
    }

    IEnumerator new_speed()
    {
        yield return new WaitForSeconds(time);
        speed_basic = default_speed;
    }
}

