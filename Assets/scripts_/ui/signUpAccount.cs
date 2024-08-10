using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class signUpAccount : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI thongbao;

    public void DangKyButton()
    {
        StartCoroutine(DangKy());
    }

    public void BackButton(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    IEnumerator DangKy()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", username.text);
        form.AddField("passwd", password.text);

        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            thongbao.text = "Kết nối không thành công";
        }
        else
        {
            string get = www.downloadHandler.text;

            switch(get)
            {
                case "exist": thongbao.text = "Tài khoản đã tồn tại"; break;
                case "OK": thongbao.text = "Đăng ký thành công"; break;
                case "ERROR": thongbao.text = "Đăng ký không thành công"; break;
                default: thongbao.text = "Không kết nối được tới sever"; break;
            }
        }
    }

    public void SignUpBackToMenu(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
