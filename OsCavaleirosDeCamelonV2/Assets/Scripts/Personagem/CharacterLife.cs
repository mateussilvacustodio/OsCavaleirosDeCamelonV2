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
    
    [Header("HUD")]
    [SerializeField] Text vidaText;
    [SerializeField] Image vidaImg;
    [SerializeField] Image manaImg;
    [SerializeField] GameObject barraMana;
    [Header("Vida e Mana")]
    public float vida;
    public float vidaVerdadeira;
    public float vidaMax = 60;
    public float mana;
    [SerializeField] float manaMax;
    [SerializeField] float duracaoLerp;
    
    [Header("Game Over e Pausa")]
    [SerializeField] GameObject gameOver;
    [SerializeField] Pause pause;
    [SerializeField] GameObject[] Character;
    [SerializeField] CharacterMoviment characterMoviment;
    [SerializeField] BoxCollider2D playerCollider;
    [Header("Dinheiro")]
    [SerializeField] Dinheiro dinheiro;
     
    
    void Start()
    {        
        characterMoviment = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>();
        playerCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
        
        vidaMax += dinheiro.aumentaVida;
        vida = vidaMax;
        vidaVerdadeira = vidaMax;

        mana = manaMax;

        if(dinheiro.arraySpecial[PlayerPrefs.GetInt("PersonagemEscolhido")] == 1) {

            barraMana.SetActive(true);

        }
    }

    void Update()
    {

        vidaText.text = vida.ToString("F0") + " / " +vidaMax.ToString();
        
        vidaImg.fillAmount = vida / vidaMax;
        manaImg.fillAmount = mana / manaMax;

        if(vida <= 0) {

            characterMoviment.characterRb.velocity = new Vector2(0,characterMoviment.characterRb.velocity.y);
            gameOver.SetActive(true);
            pause.enabled = false;
            characterMoviment.enabled = false;
            playerCollider.enabled = false;
            
        }

        if(mana < manaMax) {

            mana+=0.025f;

        }

    }

    public IEnumerator LerparValor(float danoDado) {

        float tempo = 0;
        float dano = vida - danoDado;

        if(dano > vidaMax) {

            dano = vidaMax;

        } else if(dano < 0) {

            dano = 0;

        }

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

    public IEnumerator LerparMana(float manaGasta) {

        float tempo = 0;
        float gasto = mana - manaGasta;

        while (tempo < duracaoLerp) {

            tempo += Time.deltaTime;
            mana = Mathf.Lerp(mana, gasto, tempo / duracaoLerp);

            yield return null;

        }

        mana = gasto;

    }

}
