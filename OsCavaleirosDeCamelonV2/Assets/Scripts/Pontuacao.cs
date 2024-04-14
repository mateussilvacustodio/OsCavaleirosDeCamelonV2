using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    
    [SerializeField] Text text;
    [SerializeField] float pontos;
    [SerializeField] float duracaoLerp;
    
    void Update()
    {
        
        text.text = pontos.ToString("F0").PadLeft(8, '0');

    }

    public IEnumerator LerparValor(float pontuacaoAdquirida) {

        float tempo = 0;
        float pontuacao = pontos + pontuacaoAdquirida;

        while (tempo < duracaoLerp) {

            tempo += Time.deltaTime;
            pontos = Mathf.Lerp(pontos, pontuacao, tempo / duracaoLerp);

            yield return null;

        }

        pontos = pontuacao;

    }

    public void LerparPontuacao() {

        StartCoroutine(LerparValor(100));

    }
}
