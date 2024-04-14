using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    
    [SerializeField] Transform CharacterT;
    void Update()
    {
        
        if(CharacterT.position.x < -10) {

            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);

        } else if (CharacterT.position.x > 95) {

            transform.position = new Vector3(95, transform.position.y, transform.position.z);

        } else {

            transform.position = new Vector3(CharacterT.position.x, transform.position.y, transform.position.z);
            

        }        
        
    }
}
