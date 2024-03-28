using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform CharacterT;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(CharacterT.position.x, transform.position.y, transform.position.z);
    }
}
