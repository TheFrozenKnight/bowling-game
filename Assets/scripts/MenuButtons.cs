using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public void OnExitButtonPress()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
