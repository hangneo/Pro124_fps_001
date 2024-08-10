using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_player : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        Instantiate(game_manager.instance.current_character.prefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
