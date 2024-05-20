using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.TextCore.Text;

public class Boss : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] Rigidbody2D bossRb;
    [SerializeField] Animator bossAnim;
    [SerializeField] SpriteRenderer bossSp;
    [SerializeField] Image bossVida;
    
    [Header("Partes")]
    [SerializeField] GameObject pedra;
    [SerializeField] GameObject mao;
    [Header("Vida")]
    [SerializeField] float vida;
    [SerializeField] float vidaMax;
    [Header("Etapas")]
    [SerializeField] float etapa;
    [SerializeField] float quantidadeSocos;
    [Header("Restante")]
    [SerializeField] bool isOnGround;
    [SerializeField] CinemachineImpulseSource impulseSource;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(etapa == 1) {

            bossAnim.SetBool("Abaixado", true);
            StartCoroutine(Abaixado());
            etapa = 0;
                      

        }

        if(etapa == 2) {

            bossAnim.SetBool("Pulo", true);
            Invoke("pular", 0.5f);
            StartCoroutine(Parar());

        }

        if(etapa == 3) {

            bossAnim.SetBool("Pulo", true);
            Invoke("pular", 0.5f);
            StartCoroutine(Mao());

        }

        if(Input.GetKeyDown(KeyCode.Space)) {

            mudarEtapa();

        }

        if(bossRb.velocity.y > 0) {

            bossAnim.SetBool("Pulo", false);

        } else if(bossRb.velocity.y < 0) {

            bossAnim.SetBool("Queda", true);

        }

        if(isOnGround) {

            bossAnim.SetBool("Queda", false);

        }

        bossVida.fillAmount = vida / vidaMax;

        

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            isOnGround = true;
            impulseSource.GenerateImpulseWithForce(1f);

        }

    }

    void OnCollisionExit2D(Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            isOnGround = false;

        }

    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "Arma") {

            StartCoroutine(Piscar());
            StartCoroutine(LerparValor(5));
        }

    }

    void mudarEtapa() {

        etapa = 2;

    }

    void pular() {

        bossRb.velocity = new Vector2(0, 12);

    }

    IEnumerator Parar() {

        yield return new WaitForSeconds(2f);
        bossRb.velocity = new Vector2(0,0);
        pedra.GetComponent<BossPedra>().mover = true;
        yield return new WaitForSeconds(2f);              
        etapa = 0;
    }

    IEnumerator Mao() {

        yield return new WaitForSeconds(2f);
        bossRb.velocity = new Vector2(0,0);
        mao.GetComponent<BossMao>().cair = true;
        yield return new WaitForSeconds(2f);              
        etapa = 0;              
    
    }

    IEnumerator Abaixado() {
        
        yield return new WaitForSeconds(0.25f);
        bossAnim.SetBool("Bater", true);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Esq", true);
        impulseSource.GenerateImpulseWithForce(1f);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Esq", false);
        impulseSource.GenerateImpulseWithForce(1f);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Esq", true);
        impulseSource.GenerateImpulseWithForce(1f);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Bater", false);
        impulseSource.GenerateImpulseWithForce(1f);
        quantidadeSocos ++;

        if(etapa == 0 && quantidadeSocos < 2) {

            bossAnim.SetBool("Esq", false);
            etapa = 1;

        } else {

            yield return new WaitForSeconds(0.25f);
            bossAnim.SetBool("Abaixado", false);
            bossAnim.SetBool("Esq", false);
            quantidadeSocos = 0;

        }
        
    }

    IEnumerator Piscar() {

        bossSp.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        bossSp.color = Color.white;

    }

    public IEnumerator LerparValor(float danoDado) {

        float tempo = 0;
        float dano = vida - danoDado;

        while (tempo < 0.5) {

            tempo += Time.deltaTime;
            vida = Mathf.Lerp(vida, dano, tempo / 1);
            print(dano);

            yield return null;

        }

        vida = dano;
        

    }
    
}
