using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class game_ui : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score, high_score;
    // Start is called before the first frame update
    void Start()
    {
        score.SetText($"score : {game_manager.instance.score}");
        high_score.SetText($"high score : {game_manager.instance.high_score}");
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText($"score : {game_manager.instance.get_score()}");
        high_score.SetText($"high score : {game_manager.instance.get_high_score()}");
    }
}
