using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public float max_health, current_health;
    [SerializeField] Image health_;
    [SerializeField] TextMeshProUGUI value_text;
    [SerializeField] float fill_speed;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
        update_health();
    }

    void Update()
    {
        
    }

    public void update_health()
    {
        float health_bar = current_health / max_health;
        health_.DOFillAmount(health_bar, fill_speed);
        value_text.text = $"{current_health} / {max_health}";
    }

    public void tru_mau(int tru_mau)
    {               
        current_health -= tru_mau;
        current_health = Mathf.Clamp(current_health, 0f, max_health);
        update_health();
    }
    
    public void tang_mau(int tang_mau)
    {
        current_health += tang_mau;
        current_health = Mathf.Clamp(current_health, 0f, max_health);
        update_health();
    }
  
}
