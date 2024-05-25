using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voltar : MonoBehaviour
{
    [SerializeField] string cenaVoltar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //voltar
        if(Input.GetKeyDown(KeyCode.Escape)) {

            SceneManager.LoadScene(cenaVoltar);

        }
    }
}
