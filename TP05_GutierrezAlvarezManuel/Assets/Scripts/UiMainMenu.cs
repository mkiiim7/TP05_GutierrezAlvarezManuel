using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIMainMENU : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button exitIntroMenu;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button settingsBackButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject PanelSettings;
    [SerializeField] private Slider VolumenSlider1;
    [SerializeField] private Slider VolumenSlider2;
    [SerializeField] private Slider VolumenSlider3;
    [SerializeField] public AudioMixer audioMixer;
    public bool pausa = false;


    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        exitIntroMenu.onClick.AddListener(OnexitIntroMenuClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);
        VolumenSlider1.onValueChanged.AddListener(OnVolumeChanged1);
        VolumenSlider2.onValueChanged.AddListener(OnVolumeChanged2);
        VolumenSlider3.onValueChanged.AddListener(OnVolumeChanged3);

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
        VolumenSlider1.onValueChanged.RemoveAllListeners();
        VolumenSlider2.onValueChanged.RemoveAllListeners();
        VolumenSlider3.onValueChanged.RemoveAllListeners();

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

    private void OnVolumeChanged1(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);

    }
    private void OnVolumeChanged2(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);

    }
    private void OnVolumeChanged3(float volume)
    {
        audioMixer.SetFloat("FXVolume", volume);

    }
}