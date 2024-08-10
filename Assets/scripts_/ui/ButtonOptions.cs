using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour
{
    void SignUpButtonOption(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
    void SignInButtonOption(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
