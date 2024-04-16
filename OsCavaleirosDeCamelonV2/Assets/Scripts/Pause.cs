using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    
    [SerializeField] GameObject painel;
    bool isPaused;
    [SerializeField] CharacterMoviment characterMoviment;
    
    void Start() {

        Time.timeScale = 1f;

    }
    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)) {

            if(!isPaused) {

                Pausar();
                
            } else {

                Play();

            }

        }
           
    }

    public void MudarFase(string fase) {

        SceneManager.LoadScene(fase);

    }

    public void Pausar() {

        painel.SetActive(true);
        characterMoviment.enabled = false;
        isPaused = true;
        Time.timeScale = 0f;

    }
    
    public void Play() {

        painel.SetActive(false);
        characterMoviment.enabled = true;
        isPaused = false;
        Time.timeScale = 1f;

    }
}
