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
    [SerializeField] float vidaMax = 60;
    [SerializeField] float duracaoLerp;
    [SerializeField] Image vidaImg;
    [SerializeField] GameObject gameOver;
    [SerializeField] Pause pause;
    [SerializeField] CharacterMoviment characterMoviment;
    [SerializeField] BoxCollider2D playerCollider;
     
    void Start()
    {
        vida = vidaMax;
    }

    void Update()
    {

        vidaImg.fillAmount = vida / vidaMax;

        if(vida <= 0) {

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
