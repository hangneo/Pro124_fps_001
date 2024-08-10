using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_pos : MonoBehaviour
{
    [SerializeField] Vector2 cam_pos, dir;
    [SerializeField] int dirx_1, diry_1, dirx_2, diry_2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cam_pos = Camera.main.transform.position;
        dir.x = cam_pos.x - transform.position.x;
        dir.y = cam_pos.y - transform.position.y;

        if (dir.x > dirx_1)
        {
            transform.Translate(Vector2.right * dirx_1 * 2);
        }
        
        if (dir.x < dirx_2)
        {
            transform.Translate(Vector2.right * dirx_2 * 2);
        }
        
        if (dir.y > diry_1)
        {
            transform.Translate(Vector2.up * diry_1 * 2);
        }
        
        if (dir.y < diry_2)
        {
            transform.Translate(Vector2.up * diry_2 * 2);
        }
        
    }
}
