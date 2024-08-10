using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health_quai : MonoBehaviour
{
    public float max_health, current_health;

    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }
    
    public void tru_mau(int tru_mau)
    {
        current_health -= tru_mau;
        current_health = Mathf.Clamp(current_health, 0f, max_health);
    }
}
