using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator trampolimAnim;
    [SerializeField] float forcaTrampolim;
    public CharacterMoviment characterMoviment;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collider) {

        if(collider.gameObject.tag == "Player") {

            trampolimAnim.SetBool("IsBouncing", true);
            print("Tocou no trampolim");

            characterMoviment = collider.gameObject.GetComponent<CharacterMoviment>();

            characterMoviment.characterAnim.SetBool("IsJumping", true);

            characterMoviment.characterRb.velocity = new Vector2(characterMoviment.characterRb.velocity.x, forcaTrampolim);

        }

    }

    public void pararBounce() {

        trampolimAnim.SetBool("IsBouncing", false);

    }
}
