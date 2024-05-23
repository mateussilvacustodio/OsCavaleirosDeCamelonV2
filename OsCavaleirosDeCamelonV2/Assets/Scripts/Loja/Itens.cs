using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Itens : MonoBehaviour
{
    public int posicao;
    [SerializeField] Transform[] pontos;
    [SerializeField] float velocidade;
    [SerializeField] bool podeMover;
    [SerializeField] SpriteRenderer itemSp;
    [SerializeField] int LimitePosMax;
    [SerializeField] int LimitePosMin;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) && !podeMover && posicao < LimitePosMax) {

            posicao ++;
            podeMover = true;

        } else if (Input.GetKeyUp(KeyCode.RightArrow) && !podeMover && posicao > LimitePosMin) {

            posicao --;
            podeMover = true;

        }

        if(podeMover) {

            transform.position = Vector3.MoveTowards(transform.position, pontos[posicao].position, velocidade * Time.deltaTime);

        }
        
        if(transform.position == pontos[posicao].position) {
            
            podeMover = false;
        }

        if(posicao < 3 || posicao > 5) {

            itemSp.enabled = false;


        } else {

            itemSp.enabled = true;


        }
        
    }
}
