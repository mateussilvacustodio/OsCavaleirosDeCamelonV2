using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    
    [Header("Personagem")]
    public Rigidbody2D playerCutRB;
    [SerializeField] float velocidade;
    [SerializeField] Animator playerCutAnim;
    [Header("Atos")]
    [SerializeField] int ato;
    [Header("Dialogos")]
    [SerializeField] string nomesPlayers;
    [SerializeField] string[] falasPlayers;
    [SerializeField] int falasPlayersIndex;
    [SerializeField] float typeSpeed;
    [Header("Instancias")]
    [SerializeField] GameObject dialogoObj;
    [SerializeField] Text nome;
    [SerializeField] Text falas;
    [Header("Cena")]
    [SerializeField] string cena;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(ato == 0) {

            playerCutRB.velocity = new Vector2(velocidade, playerCutRB.velocity.y);
            playerCutAnim.SetBool("IsMoving", true);



        } else {

            playerCutRB.velocity = new Vector2(0, playerCutRB.velocity.y);
            playerCutAnim.SetBool("IsMoving", false);
            
        }

        if(Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.KeypadEnter)) {

            pularDialogo();

        }

        //pular cutscene

        if(Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene(cena);

        }  

    }

    public void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "MudadorDeAto") {

            Debug.Log("Mudar o ato");
            ato = 1;
            speak();

        }

        if(collider.gameObject.name == "MudadorDeCena") {

            SceneManager.LoadScene(cena);

        }

    }

    public void speak() {

        dialogoObj.SetActive(true);
        nome.text = nomesPlayers;
        StartCoroutine(Digitar());

    }

    IEnumerator Digitar() {

        foreach (char letter in falasPlayers[falasPlayersIndex].ToCharArray())
        {
            falas.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }

    }

    public void pularDialogo() {

        if(falas.text == falasPlayers[falasPlayersIndex]) {

            if(falasPlayersIndex < falasPlayers.Length - 1) {

                falasPlayersIndex++;
                falas.text = "";
                StartCoroutine(Digitar());

            } else {

                falas.text = "";
                falasPlayersIndex = 0;
                dialogoObj.SetActive(false);
                ato = 0;

            }

        }

    }

}
