using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private UnityEngine.UI.Button playAgainButton;
    [SerializeField] private GameObject deadPanel;
    private Animator animator;
    public float currentHealth;
    private bool dead;
    [SerializeField] private AudioSource soundHurt;
    [SerializeField] private AudioSource soundGameOver;
    [SerializeField] private AudioSource musicBackGround;
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHealth = playerData.startingHealth;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playAgainButton.onClick.AddListener(GoToGamePlay);
       
    }
    private void OnDestroy()
    {
        playAgainButton.onClick.RemoveAllListeners();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0, playerData.startingHealth);

        if (currentHealth > 0 ) 
        {
            soundHurt.Play();
            animator.SetTrigger("Hurt");
            StartInvulnerability();
        }
        else 
        {
            if (dead == false) 
            {
                soundGameOver.Play();
                musicBackGround.mute = true;
              animator.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                deadPanel.SetActive(true);
            }
        }

    }

    private void GoToGamePlay()
    {

        SceneManager.LoadScene("GamePlay");
    }

    public void AddHealth (float _value)
    {

       currentHealth = Mathf.Clamp(currentHealth + _value,0, playerData.startingHealth);
    }


    public void StartInvulnerability()
    {

        StartCoroutine(Invulnerability());
    }
    public IEnumerator Invulnerability ()
    {
        Physics2D.IgnoreLayerCollision(14 , 16, true);  //14 es el layer "Player" y 16 el Layer "Enemy"
        for (int i = 0; i < numberOfFlashes; i++) 
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(invulnerabilityDuration / (numberOfFlashes * 3));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(1);

        }

        Physics2D.IgnoreLayerCollision(14, 16, false);

    }

}
