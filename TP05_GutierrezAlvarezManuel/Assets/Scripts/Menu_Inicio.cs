using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Inicio : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private UnityEngine.UI.Button exitButton;
    private void Start()
    {
        playButton.onClick.AddListener(GoToGamePlay);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }
    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
    }
    private void GoToGamePlay()
    {
       
        SceneManager.LoadScene("GamePlay");
    }
    private void OnExitButtonClicked()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
