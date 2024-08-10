using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class show_dmg : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void setDMG(int dmg_)
    {
        text.text = $"-{dmg_.ToString()}";
    }
}
