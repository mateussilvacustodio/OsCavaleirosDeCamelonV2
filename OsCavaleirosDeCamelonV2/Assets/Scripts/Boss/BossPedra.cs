using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPedra : MonoBehaviour
{
    
    public bool mover;
    [SerializeField] Rigidbody2D pedraRb;
    [SerializeField] CircleCollider2D pedraCollider;
    [SerializeField] GameObject[] Character;
    [SerializeField] CharacterMoviment characterMoviment;
    [SerializeField] BoxCollider2D characterCollider;
    [SerializeField] float posIni;
    [SerializeField] BoxCollider2D[] plataformaCollider;
    [SerializeField] BoxCollider2D[] bloqueadorCollider;
    void Start()
    {
        characterMoviment = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>();
        characterCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 200) * Time.deltaTime);

        if(mover) {

            pedraRb.velocity = new Vector2(-10,0);

        } else {

            pedraRb.velocity = new Vector2(0,0);
            transform.position = new Vector3(posIni, -0.82f, 0);

        }

        //ignorar a colisao com personagem piscando

        if(characterMoviment.isFlasing == true) {

            Physics2D.IgnoreCollision(pedraCollider, characterCollider, true);

        } else if(characterMoviment.isFlasing == false) {

            Physics2D.IgnoreCollision(pedraCollider, characterCollider, false);

        }

        //ignorar a colisao com as plataformas
        Physics2D.IgnoreCollision(pedraCollider, plataformaCollider[0]);
        Physics2D.IgnoreCollision(pedraCollider, plataformaCollider[1]);
        Physics2D.IgnoreCollision(pedraCollider, plataformaCollider[2]);
        Physics2D.IgnoreCollision(pedraCollider, plataformaCollider[3]);
        Physics2D.IgnoreCollision(pedraCollider, plataformaCollider[4]);

        
        //ignorar a colisao com os bloqueadores
        Physics2D.IgnoreCollision(pedraCollider, bloqueadorCollider[0]);
        Physics2D.IgnoreCollision(pedraCollider, bloqueadorCollider[1]);
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "PararPedra") {

            mover = false;
            PlataformaBoss.subir = false;

        }

    }
}
