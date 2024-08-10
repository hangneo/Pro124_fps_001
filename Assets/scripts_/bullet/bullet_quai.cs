using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_quai : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    health health;
    [SerializeField] GameObject pl_die;
    [SerializeField] float fire_force = 5f;
    [SerializeField] int min_damage, max_damage;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        move_player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            game_manager.instance.play_sfx("collision");
            var name = collision.attachedRigidbody.name;
            Destroy(gameObject);
            health = collision.GetComponent<health>();
            if (health != null)
            {
                var damage = Random.Range(min_damage, max_damage);
                health.tru_mau(damage);               
                if (health.current_health <= 0)
                {
                    game_manager.instance.play_sfx("die");
                    game_manager.instance.kill_player();
                    GameObject.Find(name).SetActive(false);

                    var die = Instantiate(pl_die, collision.transform.position, Quaternion.identity);
                    Destroy(die, 0.5f);
                }
            }
        }
    }  

    void move_player()
    {
        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * fire_force;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Destroy(gameObject, 2f);
    }
}
