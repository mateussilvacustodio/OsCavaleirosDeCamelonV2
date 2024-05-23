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
    [SerializeField] BoxCollider2D bossCollider;
    
    [Header("Partes")]
    [SerializeField] GameObject pedra;
    [SerializeField] GameObject[] Character;
    [SerializeField] BoxCollider2D characterCollider;
    [Header("Vida")]
    [SerializeField] float vida;
    [SerializeField] float vidaMax;
    [Header("Etapas")]
    [SerializeField] float etapa;
    [SerializeField] float quantidadeSocos;
    [SerializeField] GameObject raio;
    [SerializeField] GameObject raio2;
    [SerializeField] float ultimaEtapa;
    [Header("Temporizador")]
    [SerializeField] float tempo;
    [SerializeField] float tempoMax; 
    [Header("Restante")]
    public bool isOnGround;
    [SerializeField] CinemachineImpulseSource impulseSource;
    

    // Start is called before the first frame update
    void Start()
    {
        characterCollider = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>();
        tempo = 0;
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

        if(Input.GetKeyDown(KeyCode.P)) {

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

        //ignorar colisao com player

        Physics2D.IgnoreCollision(bossCollider, characterCollider, true);

        tempo += Time.deltaTime;

        if(tempo > tempoMax) {

            mudarEtapa();
            tempo = 0;

        }

    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            isOnGround = true;
            impulseSource.GenerateImpulseWithForce(1f);
            BossMao.poderCair = true;
            BossMao.cair = 0;
            BarraVermelha.descer = 0;
            tempo = 0;
            tempoMax = 3;

        }

    }

    void OnCollisionExit2D(Collision2D collision) {

        if(collision.gameObject.tag == "Ground") {

            isOnGround = false;

        }

    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "Arma" && bossAnim.GetBool("Pulo") == false && bossAnim.GetBool("Queda") == false && bossAnim.GetBool("Abaixado") == false) {

            StartCoroutine(Piscar());
            StartCoroutine(LerparValor(5));
        }

    }

    void mudarEtapa() {

        do {
        
            etapa = UnityEngine.Random.Range(1, 4);

        } while (etapa == ultimaEtapa);

        ultimaEtapa = etapa;

    }

    void pular() {

        bossRb.velocity = new Vector2(0, 12);

    }

    IEnumerator Parar() {

        tempoMax = 12;
        PlataformaBoss.subir = true;
        yield return new WaitForSeconds(2.5f);
        bossRb.velocity = new Vector2(0,0);
        pedra.GetComponent<BossPedra>().mover = true;
        yield return new WaitForSeconds(3f);        
        etapa = 0;
    }

    IEnumerator Mao() {

        tempoMax = 8;
        BarraVermelha.descer = 1;
        yield return new WaitForSeconds(2f);
        bossRb.velocity = new Vector2(0,0);
        if(BossMao.poderCair) {

            BossMao.cair = 1;
            BossMao.poderCair = false;
            BarraVermelha.descer = 2;

        }
        
        
        yield return new WaitForSeconds(0.5f);              
        etapa = 0;              
    
    }

    IEnumerator Abaixado() {
        
        tempoMax = 8;
        yield return new WaitForSeconds(0.25f);
        bossAnim.SetBool("Bater", true);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Esq", true);
        Instantiate(raio);
        impulseSource.GenerateImpulseWithForce(1f);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Esq", false);
        Instantiate(raio2);
        impulseSource.GenerateImpulseWithForce(1f);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Esq", true);
        Instantiate(raio);
        impulseSource.GenerateImpulseWithForce(1f);
        yield return new WaitForSeconds(0.5f);
        bossAnim.SetBool("Bater", false);
        Instantiate(raio2);
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
