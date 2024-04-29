using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePonte : MonoBehaviour
{
    [SerializeField] Transform ponteT;
    [SerializeField] BoxCollider2D ponteCollider;
    [SerializeField] Animator alavancaAnim;
    
    
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider) {

        if(collider.gameObject.name == "Arma") {

            ponteT.rotation = new Quaternion(0,0,0,0);
            ponteCollider.enabled = false;
            alavancaAnim.SetBool("IsActived", true);

        }

    } 
}
