using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loja : MonoBehaviour
{
    
    [SerializeField] Text descricaoItens;
    [SerializeField] Text Precos;
    [SerializeField] string[] textos;
    [SerializeField] float[] txt_precos;
    [SerializeField] Itens itemPocao;
    [SerializeField] Dinheiro dinheiro;

    void Start()
    {
        
    }

    void Update()
    {
        
      print(itemPocao.posicao);
      
      descricaoItens.text = textos[itemPocao.posicao - 1];
      Precos.text = txt_precos[itemPocao.posicao - 1].ToString();

      if(Input.GetKeyUp(KeyCode.Return) && dinheiro.isLerping == false && dinheiro.dinheiro >= txt_precos[itemPocao.posicao - 1]) {

        StartCoroutine(dinheiro.LerparValor(-txt_precos[itemPocao.posicao - 1]));

        if(itemPocao.posicao == 5) {

            dinheiro.quantidadePocoes ++;

        } else if (itemPocao.posicao == 4) {

            dinheiro.aumentaVida += 10;

        }
        

      }

      //voltar
        if(Input.GetKeyDown(KeyCode.Escape)) {

            PlayerPrefs.SetFloat("DinheiroTotal", dinheiro.dinheiro);
            PlayerPrefs.SetFloat("PocaoTotal", dinheiro.quantidadePocoes);
            PlayerPrefs.SetFloat("AumentoVida", dinheiro.aumentaVida);
            SceneManager.LoadScene("Mapa");

        }

    }
}
