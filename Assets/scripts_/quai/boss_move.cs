using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_move : MonoBehaviour
{
    Vector2 dir;
    Transform pl_trans;
    Animator ani;
    quai_atk quai_Atk;
    float distance;
    player_move player_Move;
    [SerializeField] float move_speed, radius;
    [SerializeField] bool is_atk;
    [SerializeField] bool delayAtk;

    // Start is called before the first frame update
    void Start()
    {
        quai_Atk = GetComponentInChildren<quai_atk>();
        ani = GetComponent<Animator>();

        var player = GameObject.FindGameObjectWithTag("Player");
        player_Move = FindObjectOfType<player_move>();

        if (player == null)
        {
            player = FindObjectOfType<GameObject>();
        }
        else
        {
            pl_trans = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dir = (pl_trans.position - transform.position).normalized;

        ani.SetFloat("x.velocity", dir.x);
        ani.SetFloat("y.velocity", dir.y);

        if (pl_trans != null && !is_atk)
        {
            transform.Translate(dir * move_speed * Time.deltaTime);
            ani.SetFloat("speed_", move_speed);
        }
        else
        {
            ani.SetFloat("speed_", 0);
        }

        if (is_atk)
        {
            if (!delayAtk)
            {
                quai_Atk.fire();
                delayAtk = true;
                StartCoroutine(DelayForAttack());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            distance = Vector2.Distance(transform.position, collision.transform.position);
            if (distance <= radius)
            {
                is_atk = true;                
            }
        }
    }

    IEnumerator DelayForAttack()
    {
        yield return new WaitForSeconds(2f);
        delayAtk = false ;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            is_atk = false;
        }
    }   
}
