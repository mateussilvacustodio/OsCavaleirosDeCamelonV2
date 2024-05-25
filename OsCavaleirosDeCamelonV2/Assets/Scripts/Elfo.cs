using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Elfo : MonoBehaviour
{
    [Header("Vida")]
    [SerializeField] float vida;
    [Header("Raycast")]
    [SerializeField] float distancia;
    [SerializeField] LayerMask layer;
    [Header("Ataque")]
    [SerializeField] Animator elfoAnim;
    [SerializeField] float timerInicial;
    [SerializeField] float timer;
    [SerializeField] GameObject flecha;
    [SerializeField] BoxCollider2D elfoCollider;
    [SerializeField] GameObject[] Character;
    [SerializeField] BoxCollider2D characterCollider;
    [Header("Dano")]
    [SerializeField] float KbX;
    [SerializeField] float KbY;
    [SerializeField] Rigidbody2D elfoRb;
    [SerializeField] CharacterMoviment characterMoviment;
    [Header("Morte")]
    [SerializeField] GameObject explosao;
    [SerializeField] Pontuacao pontuacao;
    [SerializeField] GameObject moedas;
    [SerializeField] GameObject coracao;

    void Start() {

        characterCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
        characterMoviment = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>();

    }
    
    void Update()
    {
        
        //timer para o ataque
        timer -= Time.deltaTime;

        //perceber personagem
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, this.transform.TransformDirection(Vector2.left), distancia, layer);

        if(hit && timer <= 0 && !characterMoviment.isFlasing) {

            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector2.left) * distancia, Color.red);
            Debug.Log(hit.transform.name);
            elfoAnim.SetBool("IsSeeingPlayer", true);
            timer = timerInicial;

        } else {

            Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector2.left) * distancia, Color.blue);

        }

        //dano

        if(elfoAnim.GetBool("IsDamaged") == true) {

            KbY -= Time.deltaTime * 5;
            
            if(this.transform.position.x > characterMoviment.transform.position.x) {
                
                elfoRb.velocity = new Vector2(KbX,KbY);

            } else if (this.transform.position.x < characterMoviment.transform.position.x) {

                elfoRb.velocity = new Vector2(-KbX,KbY);

            }

        }

        //ignorar a colisao com personagem piscando

        if(characterMoviment.isFlasing == true) {

            Physics2D.IgnoreCollision(elfoCollider, characterCollider, true);

        } else if(characterMoviment.isFlasing == false) {

            Physics2D.IgnoreCollision(elfoCollider, characterCollider, false);

        }

    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.name == "Arma" && elfoAnim.GetBool("IsDamaged") == false) {
            
            if(this.transform.position.x > characterMoviment.transform.position.x) {
                
                transform.rotation = new Quaternion(0,0,0,0);

            } else if (this.transform.position.x < characterMoviment.transform.position.x) {

                transform.rotation = new Quaternion(0,180,0,0);

            }
            
            vida -= 10;
            //print("elfoDanificado");
            elfoAnim.SetBool("IsDamaged", true);
            elfoAnim.SetBool("IsSeeingPlayer", false);
            timer = timerInicial;

        }

        if(collider.gameObject.tag == "Poder" && elfoAnim.GetBool("IsDamaged") == false) {
            
            if(this.transform.position.x > collider.gameObject.transform.position.x) {
                
                transform.rotation = new Quaternion(0,0,0,0);

            } else if (this.transform.position.x < collider.gameObject.transform.position.x) {

                transform.rotation = new Quaternion(0,180,0,0);

            }
            
            Destroy(collider.gameObject);
            vida -= 15;
            //print("elfoDanificado");
            elfoAnim.SetBool("IsDamaged", true);
            elfoAnim.SetBool("IsSeeingPlayer", false);
            timer = timerInicial;

        }

    }

    

    void OnCollisionEnter2D (Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            if(vida > 0) {

                elfoAnim.SetBool("IsDamaged", false);
                KbY = 2;
                timer = timerInicial;

            } else if (vida <= 0) {

                float rand = UnityEngine.Random.Range(1, 3);

                pontuacao.LerparPontuacao(100);
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
    
    public void pararAtaque() {

        elfoAnim.SetBool("IsSeeingPlayer", false);

    }

    public void criarFlecha() {

        Instantiate(flecha, this.transform.position, this.transform.rotation);

    }
}
