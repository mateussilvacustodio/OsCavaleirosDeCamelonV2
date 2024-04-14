using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinheiro : MonoBehaviour
{
    [SerializeField] Text text; 
    public float dinheiro;
    [SerializeField] float duracaoLerp;
    
    void Update()
    {
        
        text.text = "X " + dinheiro.ToString("F0").PadLeft(3, '0');

    }

    public IEnumerator LerparValor(float dinheiroAdq) {

        float tempo = 0;
        float dinheiroTotal = dinheiro + dinheiroAdq;

        while (tempo < duracaoLerp) {

            tempo += Time.deltaTime;
            dinheiro = Mathf.Lerp(dinheiro, dinheiroTotal, tempo / duracaoLerp);

            yield return null;

        }

        dinheiro = dinheiroTotal;

    }


}
