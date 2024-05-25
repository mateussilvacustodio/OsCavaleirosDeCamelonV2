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
    [SerializeField] SpriteRenderer[] esgotado;

    void Start()
    {
        
    }

    void Update()
    {
        
      print(itemPocao.posicao);
      
      descricaoItens.text = textos[itemPocao.posicao - 1];
      Precos.text = txt_precos[itemPocao.posicao - 1].ToString();

      if(Input.GetKeyUp(KeyCode.Return) && dinheiro.isLerping == false && dinheiro.dinheiro >= txt_precos[itemPocao.posicao - 1]) {

        

        if(itemPocao.posicao == 5) {

            dinheiro.quantidadePocoes ++;
            StartCoroutine(dinheiro.LerparValor(-txt_precos[itemPocao.posicao - 1]));

        } else if (itemPocao.posicao == 4) {

            dinheiro.aumentaVida += 10;
            StartCoroutine(dinheiro.LerparValor(-txt_precos[itemPocao.posicao - 1]));

        } else if(itemPocao.posicao == 3 && dinheiro.arraySpecial[0] == 0) {

            dinheiro.arraySpecial[0] = 1;
            StartCoroutine(dinheiro.LerparValor(-txt_precos[itemPocao.posicao - 1]));
            esgotado[0].enabled = true;
            

        } else if(itemPocao.posicao == 2 && dinheiro.arraySpecial[1] == 0) {

            dinheiro.arraySpecial[1] = 1;
            StartCoroutine(dinheiro.LerparValor(-txt_precos[itemPocao.posicao - 1]));
            esgotado[1].enabled = true;

        } else if(itemPocao.posicao == 1 && dinheiro.arraySpecial[2] == 0) {

            dinheiro.arraySpecial[2] = 1;
            StartCoroutine(dinheiro.LerparValor(-txt_precos[itemPocao.posicao - 1]));
            esgotado[2].enabled = true;

        }

      }

      //voltar
        if(Input.GetKeyDown(KeyCode.Escape)) {

            PlayerPrefs.SetFloat("DinheiroTotal", dinheiro.dinheiro);
            PlayerPrefs.SetFloat("PocaoTotal", dinheiro.quantidadePocoes);
            PlayerPrefs.SetFloat("AumentoVida", dinheiro.aumentaVida);
            PlayerPrefs.SetInt("Especial0", dinheiro.arraySpecial[0]);
            PlayerPrefs.SetInt("Especial1", dinheiro.arraySpecial[1]);
            PlayerPrefs.SetInt("Especial2", dinheiro.arraySpecial[2]);
            SceneManager.LoadScene("Mapa");

        }

    }
}
