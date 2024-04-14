using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterLife : MonoBehaviour
{
    
    [SerializeField] float vida;
    [SerializeField] float vidaMax = 60;
    [SerializeField] float duracaoLerp;
    [SerializeField] Image vidaImg;
    
    void Start()
    {
        vida = vidaMax;
    }

    void Update()
    {

        vidaImg.fillAmount = vida / vidaMax;

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

        if(vida <= 0) {

            SceneManager.LoadScene("Fase1");

        }

    }

    public void LerparVida() {

        StartCoroutine(LerparValor(100));

    }
}
