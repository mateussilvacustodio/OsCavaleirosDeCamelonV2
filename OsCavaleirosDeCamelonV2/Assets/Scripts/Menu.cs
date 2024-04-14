using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    void Start() {

    }
    
    public void MudarFase(string fase) {

        SceneManager.LoadScene(fase);

    }

    public void FecharJogo() {

        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();

    }
}
