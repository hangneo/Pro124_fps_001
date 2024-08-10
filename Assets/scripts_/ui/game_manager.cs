using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    bool is_gameover;
    public int score, high_score, score_1, score_2, score_3, score_4;
    public GameObject game_over, score_object, next_map, transition, win;
    public static game_manager instance;
    public character[] characters;
    public sounds[] music, sfx;
    public character current_character;
    public AudioSource music_source, sfx_source;
    public Animator ani;

    void Awake()
    {
        high_score = PlayerPrefs.GetInt("highscore");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        play_music("bg");

        if (characters.Length > 0)
        {
            current_character = characters[0];
        }
    }

    void Update()
    {
        score_map();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "map_1" || scene.name == "map_2" || scene.name == "map_3" || scene.name == "map_4")
        {
            var find_ui = GameObject.Find("game_ui");

            if (find_ui != null)
            {
                var ga_over = find_ui.transform.Find("game_over");
                var score_obj = find_ui.transform.Find("score_text");
                var next = find_ui.transform.Find("next_map");
                var transition_ = find_ui.transform.Find("transition");

                if (scene.name == "map_4")
                {
                    var win_ = find_ui.transform.Find("win");
                    if (win_ != null)
                    {
                        win = win_.gameObject;
                    }
                }

                if (ga_over != null && score_obj != null && next != null && transition_ != null)
                {
                    score_object = score_obj.gameObject;
                    game_over = ga_over.gameObject;
                    next_map = next.gameObject;
                    transition = transition_.gameObject;
                    ani = transition_.GetComponent<Animator>();
                }
                else
                {
                    return;
                }
            }
        }        
    }

    public void SetCharacter(character character)
    {
        current_character = character;
    }

    public void add_score(int score_value)
    {
        score += score_value;
        if (score > high_score)
        {
            high_score = score;
            PlayerPrefs.SetInt("highscore", high_score);
        }
    }

    public int get_score()
    {
        return score;
    }

    public int get_high_score()
    {
        return high_score;
    }

    public void kill_player()
    {
        is_gameover = true;
        player_die();
    }

    public void player_die()
    {
        if (game_over != null)
        {
            game_over.SetActive(true);
        }
    }

    public bool gameover_()
    {
        return is_gameover;
    }

    public void play_music(string name)
    {
        sounds s = Array.Find(music, x => x.name == name);

        music_source.clip = s.clip;
        music_source.Play();
    }
    
    public void play_sfx(string name)
    {
        sounds s = Array.Find(sfx, x => x.name == name);

        sfx_source.PlayOneShot(s.clip);
    } 
    
    void score_map()
    {
        var scene_name = SceneManager.GetActiveScene().name;

        if (scene_name == "map_1")
        {
            if (score >= score_1)
            {
                if (next_map != null)
                {
                    next_map.SetActive(true);
                }
            }
        }
        else if (scene_name == "map_2")
        {
            if (score >= score_2)
            {
                if (next_map != null)
                {
                    next_map.SetActive(true);
                }
            }
        }        
        else if (scene_name == "map_3")
        {
            if (score >= score_3)
            {
                if (next_map != null)
                {
                    next_map.SetActive(true);
                }
            }
        }       
        else
        {
            if (score >= score_4)
            {
                if (win != null)
                {
                    win.SetActive(true);
                }
            }
        }
    }
}