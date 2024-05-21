using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVermelha : MonoBehaviour
{
    public static float descer;
    [SerializeField] SpriteRenderer barraSp;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(descer == 1 && transform.position.y > 3) {

            transform.Translate(Vector2.down * Time.deltaTime * 10f);

        } else if (descer == 2) {

            barraSp.enabled = false;

        } else if (descer == 0) {

            transform.position = new Vector3(transform.position.x, 11.68f, transform.position.z);
            barraSp.enabled = true;

        }
                
    }
}
