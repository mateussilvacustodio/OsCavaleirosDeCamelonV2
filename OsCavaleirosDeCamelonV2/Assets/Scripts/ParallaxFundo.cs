using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFundo : MonoBehaviour
{
    [SerializeField] Transform posicao;
    [SerializeField] float velocidade;
    [SerializeField] CharacterMoviment characterMoviment;
    [SerializeField] Cutscene cutscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(characterMoviment != null) {

            if(characterMoviment.transform.position.x > -10 && characterMoviment.transform.position.x < 95) {

                if(characterMoviment.characterRb.velocity.x > 0) {

                    posicao.position += transform.right * -velocidade * Time.deltaTime;

                } else if (characterMoviment.characterRb.velocity.x < 0) {

                    posicao.position += transform.right * velocidade * Time.deltaTime;

                }

            }


        } else if (cutscene != null) {

            if(cutscene.playerCutRB.velocity.x > 0) {

                posicao.position += transform.right * -velocidade * Time.deltaTime;

            } else if (cutscene.playerCutRB.velocity.x < 0) {

                posicao.position += transform.right * velocidade * Time.deltaTime;

            }

        }
        
        
        
        
    }
}
