using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public void LoadScene(string scene_name)
    {
        SceneManager.LoadSceneAsync(scene_name);
    }

    public void open_map(int index)
    {
        var name = $"map_{index}";
        SceneManager.LoadScene(name);
    }

    public void unlock_new_map(string name)
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("unlock"))
        {
            PlayerPrefs.SetInt("unlock", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("unlocked_map", PlayerPrefs.GetInt("unlocked_map", 1) + 1);
            PlayerPrefs.Save();
        }

        StartCoroutine(transition(name));
    }

    public void rest_map()
    {
        PlayerPrefs.DeleteAll();
        game_manager.instance.score = 0;
        game_manager.instance.high_score = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator transition(string name_)
    {
        game_manager.instance.ani.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(name_);
        game_manager.instance.ani.SetTrigger("start");
    }
}
