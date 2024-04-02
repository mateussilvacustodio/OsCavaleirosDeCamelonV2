using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    float lenght;
    float StartPos;
    Transform cam;
    [SerializeField] float parallaxSpeed;
    
    void Start()
    {
        StartPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        float RePos = cam.transform.position.x * (1 - parallaxSpeed);
        float Distance = cam.transform.position.x * parallaxSpeed;

        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);

        if(RePos > StartPos + lenght) {

            StartPos += lenght;

        } else if (RePos < StartPos - lenght) {

            StartPos -= lenght;

        }

    }
}
