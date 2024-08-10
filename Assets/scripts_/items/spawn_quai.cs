using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_quai : MonoBehaviour
{
    float timer;
    GameObject quai_;
    [SerializeField] GameObject quai;
    [SerializeField] float min_time, max_time;
    // Start is called before the first frame update
    void Start()
    {
        set_time();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            GameObject quai_ = Instantiate(quai, transform.position, Quaternion.identity);
            set_time();
        }
    }

    void set_time()
    {
        timer = Random.Range(min_time, max_time);
    }
}
