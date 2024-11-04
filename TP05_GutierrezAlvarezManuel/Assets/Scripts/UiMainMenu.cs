using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UIMainMENU : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Button playButton;

    [SerializeField] private UnityEngine.UI.Button exitButton;
    [SerializeField] private UnityEngine.UI.Button exitIntroMenu;

    [SerializeField] private UnityEngine.UI.Button settingsButton;



    [SerializeField] private UnityEngine.UI.Button settingsBackButton;

    [SerializeField] private GameObject pausePanel;



    [SerializeField] private GameObject PanelSettings;

    [SerializeField] private UnityEngine.UI.Slider VolumenSlider;

    [SerializeField] public AudioSource audioSourcePlay;


    public bool pausa = false;




    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);

        exitButton.onClick.AddListener(OnExitButtonClicked);
        exitIntroMenu.onClick.AddListener(OnexitIntroMenuClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);



        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);

        VolumenSlider.onValueChanged.AddListener(OnVolumenChanged);



    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if (!pausePanel.activeSelf)
            {
                pausa = true;
                pausePanel.SetActive(true);
                PanelSettings.SetActive(false);

                Debug.Log("Pausa = true");
                Time.timeScale = 0;
            }
            else
            {
                pausa = false;
                pausePanel.SetActive(false);


                Debug.Log("Pausa = false");
                Time.timeScale = 1;
            }
        }

    }


    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        exitIntroMenu.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();

        settingsBackButton.onClick.RemoveAllListeners();


    }
    private void OnPlayButtonClicked()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pausa = false;
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

    private void OnexitIntroMenuClicked()
    {
        pausa = false;
        SceneManager.LoadScene("Menu_Inicio");
    }
    private void OnSettingsButtonClicked()
    {

        PanelSettings.SetActive(true);
        pausePanel.SetActive(false);



    }



    private void OnSettingsBackButtonClicked()
    {

        PanelSettings.SetActive(false);
        pausePanel.SetActive(true);




    }

    private void OnVolumenChanged(float volumen)
    {
        audioSourcePlay.volume = volumen;


    }


}