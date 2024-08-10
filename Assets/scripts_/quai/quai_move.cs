using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai_move : MonoBehaviour
{
    Vector2 dir;
    Transform pl_trans;
    Animator ani;
    [SerializeField] float move_speed;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();

        var player = GameObject.FindGameObjectWithTag("Player");

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

        if (pl_trans != null)
        {
            transform.Translate(dir * move_speed * Time.deltaTime);
            ani.SetFloat("speed_", move_speed);
        }
        else
        {
            ani.SetFloat("speed_", 0);
        }
    }
}

