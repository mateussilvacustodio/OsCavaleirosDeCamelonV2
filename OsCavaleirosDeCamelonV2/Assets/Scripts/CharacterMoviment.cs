using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class CharacterMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("Movimento")]
    [SerializeField] float velocidadeMov;
    public float velocidadePulo;
    public Rigidbody2D characterRb;
    public Animator characterAnim;
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
    
    void Start()
    {
        
    }

    // Update is called once per frame
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

        if(characterRb.velocity.y > 0) {

            characterAnim.SetBool("IsJumping", true);

        }
        
        if (characterRb.velocity.y < 0) {

            characterAnim.SetBool("IsDowning", true);
            characterAnim.SetBool("IsJumping", false);

        }

    }

    void OnCollisionEnter2D (Collision2D collision) {

        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform" ) {

            characterAnim.SetBool("IsDowning", false);

        }   

    }

    void OnCollisionStay2D (Collision2D collision) {

        if(collision.gameObject.tag == "Platform" && characterRb.velocity.x ==0) {

            gameObject.transform.parent= collision.transform;
            print("Estou colidindo na plaforma e minha velocidade atual é 0");
        }

        if(collision.gameObject.tag == "Platform" && characterRb.velocity.x !=0) {

            gameObject.transform.parent= null;
            print("Estou colidindo na plaforma e minha velocidade atual é diferente de 0");
        }

    }

    void OnCollisionExit2D (Collision2D collision) {

        if(collision.gameObject.tag == "Ground" && characterRb.velocity.y < 0 ) {

            characterAnim.SetBool("IsDowning", true);
        }

        if(collision.gameObject.tag == "Platform") {

            gameObject.transform.parent = null;
            print("Saí da plataforma");

        }

    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.name == "ArmaGoblim") {

            characterAnim.SetBool("IsDamaged", true);
            print("Tomei Dano");
            StartCoroutine(SairKb());
            StartCoroutine(Piscar());
            StartCoroutine(characterLife.LerparValor(10));

        }

        if(collider.gameObject.name == "Goblim" && isFlasing == false && collider.gameObject.GetComponent<Animator>().GetBool("IsDamaged") == false) {

            characterAnim.SetBool("IsDamaged", true);
            print("Tomei Dano");
            StartCoroutine(SairKb());
            StartCoroutine(Piscar());
            StartCoroutine(characterLife.LerparValor(10));

        }

    }

    IEnumerator SairKb() {

        yield return new WaitForSeconds(tempoKb);
        characterAnim.SetBool("IsDamaged", false);

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
