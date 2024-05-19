using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    
    [SerializeField] GameObject[] Character;
    [SerializeField] Transform CharacterT;
    [SerializeField] float limiteX;
    
    void Start() {

        CharacterT = Character[PlayerPrefs.GetInt("PersonagemEscolhido")].GetComponent<Transform>();

    }

    void Update()
    {
        
        if(CharacterT.position.x < -10) {

            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);

        } else if (CharacterT.position.x > limiteX) {

            transform.position = new Vector3(limiteX, transform.position.y, transform.position.z);

        } else {

            transform.position = new Vector3(CharacterT.position.x, transform.position.y, transform.position.z);
            

        }        
        
    }
}
