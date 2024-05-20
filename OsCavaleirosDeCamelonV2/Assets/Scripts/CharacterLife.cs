using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CharacterLife : MonoBehaviour
{
    
    public float vida;
    public float vidaVerdadeira;
    [SerializeField] float vidaMax = 60;
    [SerializeField] float duracaoLerp;
    [SerializeField] Image vidaImg;
    [SerializeField] GameObject gameOver;
    [SerializeField] Pause pause;
    [SerializeField] GameObject[] Character;
    [SerializeField] CharacterMoviment characterMoviment;
    [SerializeField] BoxCollider2D playerCollider;
     
    void Start()
    {
        characterMoviment = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>();
        playerCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
        vida = vidaMax;
        vidaVerdadeira = vidaMax;
    }

    void Update()
    {

        vidaImg.fillAmount = vida / vidaMax;

        if(vida <= 0) {

            characterMoviment.characterRb.velocity = new Vector2(0,characterMoviment.characterRb.velocity.y);
            gameOver.SetActive(true);
            pause.enabled = false;
            characterMoviment.enabled = false;
            playerCollider.enabled = false;
            
        }

    }

    public IEnumerator LerparValor(float danoDado) {

        float tempo = 0;
        float dano = vida - danoDado;

        while (tempo < duracaoLerp) {

            tempo += Time.deltaTime;
            vida = Mathf.Lerp(vida, dano, tempo / duracaoLerp);

            yield return null;

        }

        vida = dano;

    }

    public void LerparVida() {

        StartCoroutine(LerparValor(100));

    }
}
