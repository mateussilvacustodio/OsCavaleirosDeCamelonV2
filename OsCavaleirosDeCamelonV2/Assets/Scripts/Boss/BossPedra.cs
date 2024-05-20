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
    // Start is called before the first frame update
    void Start()
    {
        characterMoviment = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>();
        characterCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 200) * Time.deltaTime);

        if(mover) {

            pedraRb.velocity = new Vector2(-10,0);

        } else {

            transform.position = new Vector3(14.33f, -0.82f, 0);

        }

        //ignorar a colisao com personagem piscando

        if(characterMoviment.isFlasing == true) {

            Physics2D.IgnoreCollision(pedraCollider, characterCollider, true);

        } else if(characterMoviment.isFlasing == false) {

            Physics2D.IgnoreCollision(pedraCollider, characterCollider, false);

        }
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "PararPedra") {

            mover = false;

        }

    }
}
