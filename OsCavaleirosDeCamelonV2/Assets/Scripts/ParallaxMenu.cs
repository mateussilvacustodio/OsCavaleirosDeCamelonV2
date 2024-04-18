using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    [SerializeField] SpriteRenderer nuvemSP;
    [SerializeField] float tamanhoInicial;
    [SerializeField] float velocidade;
    [SerializeField] float limite;

    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        nuvemSP.size = new Vector2(tamanhoInicial, nuvemSP.size.y);

        tamanhoInicial += Time.deltaTime * velocidade;
        print(Time.deltaTime);    

        if(tamanhoInicial >= limite) {

            tamanhoInicial = 20;

        } 

    }
}
