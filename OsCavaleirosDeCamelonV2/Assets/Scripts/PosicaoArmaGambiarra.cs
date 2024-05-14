using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicaoArmaGambiarra : MonoBehaviour
{
    [SerializeField] Transform transformArma;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transformArma.position;
        transform.rotation = transformArma.rotation;
    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "Alavanca") {

            print("Descer ponte");

        }

    } 
}
