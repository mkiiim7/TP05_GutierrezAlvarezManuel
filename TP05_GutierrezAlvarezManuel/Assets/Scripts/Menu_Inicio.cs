using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Inicio : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(GoToGamePlay);
    }
    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
    }

    private void GoToGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
