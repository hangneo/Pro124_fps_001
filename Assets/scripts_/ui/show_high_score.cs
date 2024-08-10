using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class show_high_score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI show_high_score_;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        show_high_score_.SetText($"{game_manager.instance.get_high_score()}");
    }
}
