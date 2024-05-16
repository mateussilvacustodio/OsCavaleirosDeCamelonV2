using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Espada : MonoBehaviour
{
    [Header("Animacao")]
    [SerializeField] bool up;
    [SerializeField] float velocidade;
    [SerializeField] float timer;
    [SerializeField] float timerInicial;
    [Header("Movimentacao")]
    [SerializeField] bool movimentar;
    [SerializeField] int pos;
    [SerializeField] float speed;
    [SerializeField] Transform[] fasesTransform;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position, fasesTransform[0].position, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //animacao de subir e descer a espada
        timer -= Time.deltaTime;
        
        if(up) {

            transform.Translate(Vector2.up * Time.deltaTime * velocidade);

        } else {

            transform.Translate(Vector2.down * Time.deltaTime * velocidade);

        }

        if(timer < 0) {

            timer = timerInicial;

            if(up) {

                up = false;

            } else if (!up) {

                up = true;
                
            }
 
        }

        //movimentacao da espada
        if(Input.GetKeyDown(KeyCode.RightArrow) && pos < 7 && !movimentar) {
            pos ++;
            movimentar = true;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) && pos > 1 && !movimentar) {
            pos --;
            movimentar = true;
        }

        if(movimentar) {
            transform.position = Vector3.MoveTowards(transform.position, fasesTransform[pos-1].position, speed * Time.deltaTime);
        }

        if(transform.position == fasesTransform[pos -1].position) {
            movimentar = false;
        }

        //entrar nas fases
        if(Input.GetKeyDown(KeyCode.Return)) {

            SceneManager.LoadScene(pos);

        }


    }

}
