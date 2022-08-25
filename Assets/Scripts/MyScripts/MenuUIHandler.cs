using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public GameObject inputField;
    public static string playerName;
    public Text bestScoreText;

    private void Start()
    {
        MenuManager.Instance.LoadBestPlayer();
        bestScoreText.text = "Best Score: " + MenuManager.Instance.bestPlayerName + ": " + MenuManager.Instance.bestScoreee;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName()
    {
        playerName = inputField.GetComponent<TMP_InputField>().text;
    }

    public void ExitButton()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}
