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


    private void Awake()
    {
        currentHealth = playerData.startingHealth;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playAgainButton.onClick.AddListener(GoToGamePlay);
       ;
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
            animator.SetTrigger("Hurt");
        }
        else 
        {
            if (dead == false) 
            {
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


}
