using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class getScore : MonoBehaviour
{
    public TMP_InputField token;
    public TextMeshProUGUI response;

    public void GetButton()
    {
        StartCoroutine(GetScore());
    }

    public void BackButton(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    IEnumerator GetScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            response.text = "Get không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;
            if (get == "empty")
            {
                response.text = "Các trường dữ liệu không thể để trống";
            }
            else if (get == "" || get == null)
            {
                response.text = "Bạn phải đăng nhập để thực hiện thao tác này";
            }
            else
            {
                response.text = "Get thành công";
                PlayerPrefs.SetString("score", get);
                Debug.Log(get);
            }
        }
    }
}