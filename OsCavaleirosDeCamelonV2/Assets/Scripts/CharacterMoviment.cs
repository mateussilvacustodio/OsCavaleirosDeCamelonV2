using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class CharacterMoviment : MonoBehaviour
{    
    [Header("Movimento")]
    [SerializeField] float velocidadeMov;
    public float velocidadePulo;
    public Rigidbody2D characterRb;
    public Animator characterAnim;
    [SerializeField] bool isOnGround;
    [Header("Ataque")]
    public BoxCollider2D armaCollider;
    [Header("Dano")]
    [SerializeField] float KbX;
    [SerializeField] float KbY;
    [SerializeField] float tempoKb;
    [SerializeField] SpriteRenderer characterSp;
    public bool isFlasing;
    [Header("Vida")]
    [SerializeField] CharacterLife characterLife;
    [Header("Moedas")]
    [SerializeField] Dinheiro dinheiro;

    void Update()
    {
        //mover
        float horizontal = Input.GetAxisRaw("Horizontal") * velocidadeMov;

        if(characterAnim.GetBool("IsAttacking") == false && characterAnim.GetBool("IsDamaged") == false) {

            characterRb.velocity = new Vector2(horizontal, characterRb.velocity.y);

        } else if(characterAnim.GetBool("IsAttacking") == true && characterAnim.GetBool("IsDamaged") == false) {

            characterRb.velocity = new Vector2(0, characterRb.velocity.y);

        } else if(characterAnim.GetBool("IsDamaged") == true) {

            characterRb.velocity = new Vector2(KbX, KbY);

        }

        //pular
        if(Input.GetButtonDown("Jump") && characterAnim.GetBool("IsJumping") == false && characterAnim.GetBool("IsDowning") == false) {

            characterRb.velocity = new Vector2(characterRb.velocity.x, velocidadePulo);

        }

        //flipar
        if(horizontal > 0) {

            transform.rotation = new Quaternion(0,0,0,0);

        } else if (horizontal < 0) {

            transform.rotation = new Quaternion(0,180,0,0);

        }

        //ataque
        if(Input.GetButtonDown("Fire1") && characterAnim.GetBool("IsJumping") == false && characterAnim.GetBool("IsDowning") == false) {

            characterAnim.SetBool("IsAttacking", true);

        }

        //animacoes
        if(horizontal == 0) {

            characterAnim.SetBool("IsMoving", false);

        } else {

            characterAnim.SetBool("IsMoving", true);

        }

        if(characterRb.velocity.y > 0 && !isOnGround) {

            characterAnim.SetBool("IsJumping", true);
            print("IsUpping");

        }
        
        if (characterRb.velocity.y < 0 && !isOnGround) {

            characterAnim.SetBool("IsDowning", true);
            characterAnim.SetBool("IsJumping", false);
            //print("IsDowning");

        }

    }

    void OnCollisionEnter2D (Collision2D collision) {

        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.tag == "Platform" ) {

            characterAnim.SetBool("IsDowning", false);
            //print("Toquei no chao");
            isOnGround = true;

        }

        if(collision.gameObject.tag == "Moeda") {

            dinheiro.dinheiro += 1;
            Destroy(collision.gameObject);

        }

        if(collision.gameObject.tag == "Coracao") {

            StartCoroutine(characterLife.LerparValor(-10));
            characterLife.vidaVerdadeira += 10;
            Destroy(collision.gameObject);

        }  

    }

    void OnCollisionStay2D (Collision2D collision) {

        if(collision.gameObject.tag == "Platform" && characterRb.velocity.x ==0) {

            gameObject.transform.parent= collision.transform;
            //print("Estou colidindo na plaforma e minha velocidade atual é 0");
        }

        if(collision.gameObject.tag == "Platform" && characterRb.velocity.x !=0) {

            gameObject.transform.parent= null;
            //print("Estou colidindo na plaforma e minha velocidade atual é diferente de 0");
        }

    }

    void OnCollisionExit2D (Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            isOnGround = false;

            if(characterRb.velocity.y < 0) {

                characterAnim.SetBool("IsDowning", true);

            }
            
        }

        if(collision.gameObject.tag == "Platform") {

            isOnGround = false;
            gameObject.transform.parent = null;
            //print("Saí da plataforma");

        }

    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.name == "ArmaGoblim") {

            if(collider.transform.position.x < transform.position.x && KbX < 0) {

                KbX *= -1;

            } else if (collider.transform.position.x >= transform.position.x && KbX > 0) {

                KbX *= -1;

            }
            
            characterAnim.SetBool("IsDamaged", true);
            characterLife.vidaVerdadeira -= collider.gameObject.GetComponentInParent<Goblin>().ataque;
            StartCoroutine(SairKb());
            StartCoroutine(Piscar());
            StartCoroutine(characterLife.LerparValor(collider.gameObject.GetComponentInParent<Goblin>().ataque));

        }

        if(collider.gameObject.tag == "Goblim" && isFlasing == false && collider.gameObject.GetComponent<Animator>().GetBool("IsDamaged") == false) {

            print("tomei dano");
            characterAnim.SetBool("IsDamaged", true);
            characterLife.vidaVerdadeira -= collider.gameObject.GetComponent<Goblin>().ataque;
            StartCoroutine(SairKb());
            StartCoroutine(Piscar());
            StartCoroutine(characterLife.LerparValor(collider.gameObject.GetComponent<Goblin>().ataque));

        }

        if(collider.gameObject.tag == "Flecha" && isFlasing == false) {

            print("tomei dano");
            characterAnim.SetBool("IsDamaged", true);
            characterLife.vidaVerdadeira -= 10;
            StartCoroutine(SairKb());
            StartCoroutine(Piscar());
            StartCoroutine(characterLife.LerparValor(10));
            Destroy(collider.gameObject);

        }

        if(collider.gameObject.tag == "Elfo" && isFlasing == false && collider.gameObject.GetComponent<Animator>().GetBool("IsDamaged") == false) {

            print("tomei dano");
            characterAnim.SetBool("IsDamaged", true);
            characterLife.vidaVerdadeira -= 10;
            StartCoroutine(SairKb());
            StartCoroutine(Piscar());
            StartCoroutine(characterLife.LerparValor(10));

        }

        if(collider.gameObject.name == "Morte") {

            characterLife.vidaVerdadeira = 0;
            characterLife.LerparVida();
            characterRb.velocity = new Vector2(0,characterRb.velocity.y);
            this.enabled = false;            

        }        

    }

    IEnumerator SairKb() {

        yield return new WaitForSeconds(tempoKb);
        
        if(characterLife.vidaVerdadeira > 0) {

            characterAnim.SetBool("IsDamaged", false);

        }
    
    }

    IEnumerator Piscar() {

        isFlasing = true;

        for(int i = 0; i <= 8; i++) {

            characterSp.enabled = false;
            yield return new WaitForSeconds(0.1f);
            characterSp.enabled = true;
            yield return new WaitForSeconds(0.1f);

        }

        isFlasing = false;

    }

    public void pararAtaque() {

        characterAnim.SetBool("IsAttacking", false);
        armaCollider.enabled = false;

    }

    public void iniciarAtaque() {

        armaCollider.enabled = true;

    }


}
