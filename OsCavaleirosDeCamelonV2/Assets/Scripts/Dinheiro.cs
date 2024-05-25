using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dinheiro : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text pocao_text;
    public float dinheiro;
    [SerializeField] float duracaoLerp;
    public bool isLerping;
    public float quantidadePocoes;
    public float aumentaVida;
    [Header("Especiais")]
    public int[] arraySpecial;
    
    void Awake() {

        dinheiro = PlayerPrefs.GetFloat("DinheiroTotal");
        quantidadePocoes = PlayerPrefs.GetFloat("PocaoTotal");
        aumentaVida = PlayerPrefs.GetFloat("AumentoVida");
        arraySpecial[0] = PlayerPrefs.GetInt("Especial0");
        arraySpecial[1] = PlayerPrefs.GetInt("Especial1");
        arraySpecial[2] = PlayerPrefs.GetInt("Especial2");
        // dinheiro = 0;
        // quantidadePocoes = 0;
        // aumentaVida = 0;
        // arraySpecial[0] = 0;
        // arraySpecial[1] = 0;
        // arraySpecial[2] = 0;

    }
    
    void Start() {

        

    }

    void Update()
    {
        
        text.text = "X " + dinheiro.ToString("F0").PadLeft(3, '0');
        pocao_text.text = "X " + quantidadePocoes.ToString("F0").PadLeft(3, '0');

    }

    public IEnumerator LerparValor(float dinheiroAdq) {

        isLerping = true;

        float tempo = 0;
        float dinheiroTotal = dinheiro + dinheiroAdq;

        while (tempo < duracaoLerp) {

            tempo += Time.deltaTime;
            dinheiro = Mathf.Lerp(dinheiro, dinheiroTotal, tempo / duracaoLerp);
            
            yield return null;

        }

        dinheiro = dinheiroTotal;
        
        isLerping = false;

    }


}
