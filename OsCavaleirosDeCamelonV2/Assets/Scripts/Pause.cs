using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    
    [SerializeField] GameObject painel;
    public bool isPaused;
    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)) {

            if(!isPaused) {

                painel.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
                
            } else {

                painel.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;

            }

        }
           
    }
}
