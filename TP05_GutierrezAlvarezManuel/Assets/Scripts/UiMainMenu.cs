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
    [SerializeField] private Slider VolumenSlider;
    [SerializeField] public AudioMixer audioMixer;
    public bool pausa = false;


    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        exitIntroMenu.onClick.AddListener(OnexitIntroMenuClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        settingsBackButton.onClick.AddListener(OnSettingsBackButtonClicked);
        VolumenSlider.onValueChanged.AddListener(OnVolumeChanged);



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
        VolumenSlider.onValueChanged.RemoveAllListeners();

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

    private void OnVolumeChanged(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);

    }
}