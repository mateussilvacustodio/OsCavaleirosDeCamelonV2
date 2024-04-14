using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasVoadoras : MonoBehaviour
{
    [SerializeField] float velocidade;
    [SerializeField] float tempo;
    [SerializeField] float tempoMax;
    void Update()
    {
        transform.position += new Vector3(velocidade, 0, 0) * Time.deltaTime;

        tempo -= Time.deltaTime;

        if(tempo < 0) {

            velocidade *= -1;
            tempo = tempoMax;
        }
    }
}
