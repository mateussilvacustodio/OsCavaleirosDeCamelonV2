using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AtivarPersonagem : MonoBehaviour
{
    
    [SerializeField] GameObject[] Character;
    public static bool cutscene;
    [SerializeField] BoxCollider2D bloqueadorCollider;
    [SerializeField] BoxCollider2D bloqueadorCollider2;
    [SerializeField] GameObject[] foto;
    // Start is called before the first frame update
    void Awake() {

      Character[PlayerPrefs.GetInt("PersonagemEscolhido")].SetActive(true);
      foto[PlayerPrefs.GetInt("PersonagemEscolhido")].SetActive(true);
      cutscene = true;

    }
    
    void Start()
    {
        Invoke("desativarCutscene", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        //print(cutscene);
        
        if(cutscene) {

          Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>().enabled = false;
          Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<Rigidbody2D>().velocity = new Vector2(Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>().velocidadeMov, Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>().characterRb.velocity.y);
          Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>().characterAnim.SetBool("IsMoving", true);

          Physics2D.IgnoreCollision(Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>(), bloqueadorCollider, true);

          if(bloqueadorCollider2 != null) {

            Physics2D.IgnoreCollision(Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>(), bloqueadorCollider2, true);

          }

        } else if(!cutscene) {

          Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<CharacterMoviment>().enabled = true;

          Physics2D.IgnoreCollision(Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>(), bloqueadorCollider, false);

          if(bloqueadorCollider2 != null) {

            Physics2D.IgnoreCollision(Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<BoxCollider2D>(), bloqueadorCollider2, false);

          }

        }
    }

    void desativarCutscene() {

      cutscene = false;

    }

    void ativarCutscene() {



    }
}
