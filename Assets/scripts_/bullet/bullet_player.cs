using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_player : MonoBehaviour
{
    Rigidbody2D rb;
    health_quai health;
    Weapon weapon;
    [SerializeField] GameObject quai_die;
    [SerializeField] List<quai_drop> drops;
    [SerializeField] int fire_force, count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * fire_force;        
        Destroy(gameObject, 1);

        weapon = FindObjectOfType<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("quai"))
        {
            game_manager.instance.play_sfx("collision");
            var name = collision.attachedRigidbody.name;
            Destroy(gameObject);
            health = collision.GetComponent<health_quai>();
            if (health != null)
            {
                var damage = weapon.take_damage();
                health.tru_mau(damage);
                dmg.instance.random_dmg_text(damage, collision.transform);

                if (health.current_health <= 0)
                {
                    game_manager.instance.add_score(count);
                    game_manager.instance.play_sfx("lv_up");
                    GameObject.Find(name).SetActive(false);

                    var die = Instantiate(quai_die, collision.transform.position, Quaternion.identity);
                    Destroy(die, 0.5f);

                    drop_item(collision.transform.position);
                }
            }                        
        }
    }

    void drop_item(Vector3 pos)
    {
        var random_item = Random.Range(0, drops.Count);
        Instantiate(drops[random_item].item, pos, Quaternion.identity);
    }   
}
