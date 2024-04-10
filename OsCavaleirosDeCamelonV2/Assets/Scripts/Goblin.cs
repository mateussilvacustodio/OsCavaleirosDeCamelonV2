using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    
    [Header("Movimentação")]
    [SerializeField] Rigidbody2D goblimRb;
    [SerializeField] Animator goblimAnim;
    [SerializeField] float velocidade;
    [Header("Dano")]
    [SerializeField] float KBX;
    [SerializeField] float KBY;
    [SerializeField] int vida;
    [Header("Morte")]
    [SerializeField] GameObject explosao;
    [SerializeField] Pontuacao pontuacao;
    [SerializeField] GameObject moedas;
    [SerializeField] GameObject coracao;
    [Header("Raycast")]
    [SerializeField] float distancia;
    [SerializeField] LayerMask layer;
    [Header("Ataque")]
    [SerializeField] CircleCollider2D goblimArma;
    [SerializeField] CharacterMoviment characterMoviment;
    [SerializeField] BoxCollider2D goblimCollider;
    [SerializeField] BoxCollider2D characterCollider;

    void Update()
    {
        
        //movimentacao
        if(goblimAnim.GetBool("IsDamaged") == false && goblimAnim.GetBool("IsSeeingPlayer") == false) {

            goblimRb.velocity = new Vector2(velocidade, goblimRb.velocity.y);

        } else if (goblimAnim.GetBool("IsDamaged") == true) {

            if(this.transform.position.x > characterMoviment.transform.position.x) {
                
                goblimRb.velocity = new Vector2(KBX,KBY);

            } else if (this.transform.position.x < characterMoviment.transform.position.x) {

                goblimRb.velocity = new Vector2(-KBX,KBY);

            }

        } else if (goblimAnim.GetBool("IsSeeingPlayer") == true) {

            goblimRb.velocity = new Vector2(0,0);

        }

        //animacao
        if(velocidade != 0 && goblimAnim.GetBool("IsDamaged") == false) {

            goblimAnim.SetBool("IsMoving", true);

        }

        //flipar
        if(velocidade > 0) {

            transform.rotation = new Quaternion(0, 180, 0, 0);

        } else if (velocidade < 0) {

            transform.rotation = new Quaternion(0, 0, 0, 0);

        }

        //dano
        if(goblimAnim.GetBool("IsDamaged") == true) {

            KBY -= Time.deltaTime * 5;

        }

        //perceber personagem

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.TransformDirection(Vector2.left), distancia, layer);

        if(hit && characterMoviment.isFlasing == false) {

            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector2.left * distancia), Color.red);
            Debug.Log(hit.transform.name);
            goblimAnim.SetBool("IsSeeingPlayer", true);


        } else {

            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector2.left * distancia), Color.blue);

        }

        //ignorar a colisao com personagem piscando

        if(characterMoviment.isFlasing == true) {

            Physics2D.IgnoreCollision(goblimCollider, characterCollider, true);

        } else if(characterMoviment.isFlasing == false) {

            Physics2D.IgnoreCollision(goblimCollider, characterCollider, false);

        }
    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.name == "Direita") {

            if(velocidade > 0) {

                velocidade = -velocidade;
 
            }

        }

        if(collider.gameObject.name == "Esquerda") {

            if(velocidade < 0) {

                velocidade = -velocidade;

            }

        }

        if(collider.gameObject.name == "Arma" && goblimAnim.GetBool("IsDamaged") == false) {

            vida -= 10;
            goblimAnim.SetBool("IsDamaged", true);
            

        }

    }

    void OnCollisionExit2D (Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            //print("Saí do chao");

        }

    }

    void OnCollisionEnter2D (Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            //print("Voltei ao chao");

            if(vida > 0) {

                goblimAnim.SetBool("IsDamaged", false);
                KBY = 2;

            } else if(vida <= 0) {
                
                float rand = Random.Range(1, 3);

                pontuacao.LerparPontuacao();
                if(rand == 1 ) {

                    Instantiate(moedas, this.transform.position, this.transform.rotation);

                } else if (rand == 2) {

                    Instantiate(coracao, this.transform.position, this.transform.rotation);

                }
                
                Instantiate(explosao, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);

            }
            

        }

    }

    public void iniciarAtaque() {

        goblimArma.enabled = true;

    }

    public void pararAtaque() {

        goblimArma.enabled = false;
        goblimAnim.SetBool("IsSeeingPlayer", false);
        

    }
}
