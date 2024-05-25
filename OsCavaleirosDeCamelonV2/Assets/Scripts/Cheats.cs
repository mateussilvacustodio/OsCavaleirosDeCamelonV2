using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    [SerializeField] InputField inputField;
    [SerializeField] Text cheatAtivadoText;
    [SerializeField] Text cheatIncorretoText;
    [SerializeField] string[] cheats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //voltar
        if(Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene("Opções");

        }
    }

    public void validarCheat() {

        string input = inputField.text;

        inputField.text = "";
        
        if(input == cheats[0]) {

            //print(input);
            cheatAtivadoText.enabled = true;
            Invoke("esconderCheatAtivado", 0.75f);
            PlayerPrefs.SetFloat("DinheiroTotal", PlayerPrefs.GetFloat("DinheiroTotal") + 50);

        } else if(input == cheats[1]) {

            //print(input);
            cheatAtivadoText.enabled = true;
            Invoke("esconderCheatAtivado", 0.75f);
            PlayerPrefs.SetFloat("PocaoTotal", PlayerPrefs.GetFloat("PocaoTotal") + 5);

        } else if(input == cheats[2]) {

            //print(input);
            cheatAtivadoText.enabled = true;
            Invoke("esconderCheatAtivado", 0.75f);
            PlayerPrefs.SetFloat("AumentoVida", PlayerPrefs.GetFloat("AumentoVida") + 10);

        } else if(input == cheats[3]) {

            //print(input);
            cheatAtivadoText.enabled = true;
            Invoke("esconderCheatAtivado", 0.75f);
            PlayerPrefs.SetFloat("DinheiroTotal", 0);
            PlayerPrefs.SetFloat("PocaoTotal", 0);
            PlayerPrefs.SetFloat("AumentoVida", 0);
            PlayerPrefs.SetInt("Especial0", 0);
            PlayerPrefs.SetInt("Especial1", 0);
            PlayerPrefs.SetInt("Especial2", 0);

        } else {

            //print(input);
            cheatAtivadoText.enabled = false;
            cheatIncorretoText.enabled = true;
            Invoke("esconderCheatAtivado", 0.75f);

        }

    }

    void esconderCheatAtivado() {

        cheatAtivadoText.enabled = false;
        cheatIncorretoText.enabled = false;

    }

    
}
