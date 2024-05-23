using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossMao : MonoBehaviour
{
    [Header("Componentes Mao")]
    [SerializeField] Rigidbody2D maoRb;
    [SerializeField] BoxCollider2D maoCollider;
    public static float cair;
    public static bool poderCair;
    [SerializeField] float subir;
    [SerializeField] Transform posIni;
    [Header("Componentes Boss")]
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] Boss boss;
    [SerializeField] BoxCollider2D bossCollider;
    [Header("Componentes Personagem")]
    [SerializeField] GameObject[] Character;
    [SerializeField] BoxCollider2D characterCollider;
    [SerializeField] CharacterMoviment characterMoviment;
    
    // Start is called before the first frame update
    void Start()
    {
        characterMoviment = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>();
        characterCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
        cair = 0;
        poderCair = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cair == 1 && subir == 0) {

            maoRb.gravityScale = 1.5f;

        }
        
        if(cair == 0) {

            maoRb.gravityScale = 0;
            maoRb.velocity = new Vector2(0,0);
            transform.position = posIni.position;
            

        }
        
        if (subir == 1) {

            maoRb.gravityScale = -1.5f;

        }

        if(boss.GetComponent<Boss>().isOnGround) {

            subir = 0;

        }

        //ignorar a colisao com personagem piscando

        if(characterMoviment.isFlasing == true) {

            Physics2D.IgnoreCollision(maoCollider, characterCollider, true);

        } else if(characterMoviment.isFlasing == false) {

            Physics2D.IgnoreCollision(maoCollider, characterCollider, false);

        }

        //ignorar a colisao com o boss

        Physics2D.IgnoreCollision(maoCollider, bossCollider, true);

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "Ground" && cair != 2) {

            impulseSource.GenerateImpulseWithForce(1f);
            StartCoroutine(Voltar());
                                   

        }

    }

    IEnumerator Voltar() {

        yield return new WaitForSeconds(0.5f);
        subir = 1;
        print(cair);
                
    }
}
