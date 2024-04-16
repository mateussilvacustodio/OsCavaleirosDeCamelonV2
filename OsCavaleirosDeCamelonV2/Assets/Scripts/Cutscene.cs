using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D playerCutRB;
    [SerializeField] float velocidade;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerCutRB.velocity = new Vector2(velocidade, playerCutRB.velocity.y);

    }
}
