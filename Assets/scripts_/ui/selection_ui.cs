using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class selection_ui : MonoBehaviour
{
    public GameObject option;
    public Transform normal_character, selected_character;

    private void Start()
    {
        foreach (character c in game_manager.instance.characters)
        {
            GameObject option_ = Instantiate(option, transform);
            Button button = option_.GetComponent<Button>();

            button.onClick.AddListener(() => {
                game_manager.instance.SetCharacter(c);
                if (selected_character != null)
                {
                    normal_character = selected_character;
                }

                selected_character = option_.transform;
            });

            TextMeshProUGUI text = option_.GetComponentInChildren<TextMeshProUGUI>();
            text.text = c.name;

            Image image = option_.GetComponentInChildren<Image>();
            image.sprite = c.icon;
        }
    }

    private void Update()
    {
        if (selected_character != null)
        {
            selected_character.localScale = Vector3.Lerp(selected_character.localScale, new Vector3(1.2f, 1.2f, 1.2f), Time.deltaTime * 10);
        }

        if (normal_character != null)
        {
            normal_character.localScale = Vector3.Lerp(normal_character.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10);
        }
    }
}
