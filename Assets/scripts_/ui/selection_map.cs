using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selection_map : MonoBehaviour, IEndDragHandler
{
    int current_map_sl;
    Vector3 target_pos;
    float drag;
    [SerializeField] int max_map;
    [SerializeField] Vector3 next_map;
    [SerializeField] RectTransform map_rect;
    [SerializeField] float tw_time;
    [SerializeField] LeanTweenType tw_type;
    [SerializeField] Image[] image_;
    [SerializeField] Sprite closed, open;
    [SerializeField] Button next_btton, previous_button;
    [SerializeField] List<Button> buttons;

    void Awake()
    {
        update_map();
    }

    void update_map()
    {
        var unlocked_map = PlayerPrefs.GetInt("unlocked_map", 1);

        unlocked_map = Mathf.Clamp(unlocked_map, 1, buttons.Count);

        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlocked_map; i++)
        {
            buttons[i].interactable = true;
        }

        current_map_sl = 1;
        target_pos = map_rect.localPosition;
        drag = Screen.width / 15;
        update_bar();
        update_button();
    }

    public void next()
    {
        if (current_map_sl < max_map)
        {
            current_map_sl++;
            target_pos += next_map;
            move_map();
        }
    }
    
    public void previous()
    {
        if (current_map_sl > 1)
        {
            current_map_sl--;
            target_pos -= next_map;
            move_map();
        }
    }

    void move_map()
    {
        map_rect.LeanMoveLocal(target_pos, tw_time).setEase(tw_type);
        update_bar();
        update_button();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > drag)
        {
            if (eventData.position.x > eventData.pressPosition.x)
            {
                previous();
            }
            else
            {
                next();
            }
        }
        else
        {
            move_map();
        }
    }

    void update_bar()
    {
        foreach (var i in image_)
        {
            i.sprite = closed;
        }
        image_[current_map_sl - 1].sprite = open;
    }

    void update_button()
    {
        next_btton.interactable = true;
        previous_button.interactable = true;

        if (current_map_sl == 1)
        {
            previous_button.interactable = false;
        }
        else if (current_map_sl == max_map)
        {
            next_btton.interactable = false;
        }
    }
}
