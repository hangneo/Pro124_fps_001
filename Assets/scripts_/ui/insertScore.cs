using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class insertScore : MonoBehaviour
{
    public TMP_InputField token;
    public TMP_InputField playerName;
    public TMP_InputField score;
    public TextMeshProUGUI response;

    public void InsertButton()
    {
        StartCoroutine(InsertScore());
    }

    public void BackButton(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    IEnumerator InsertScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token.text);
        form.AddField("playerName", playerName.text);
        form.AddField("score", score.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/InsertHighscore.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            response.text = "Insert không thành công";
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
                response.text = "";
            }
            else if (get.Contains("Lỗi"))
            {
                response.text = "Không kết nối được tới server";
            }
            else
            {
                response.text = "Insert thành công";
            }
        }
    }
}