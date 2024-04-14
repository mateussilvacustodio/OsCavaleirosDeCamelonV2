using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    [SerializeField] Animator trampolimAnim;
    [SerializeField] float forcaTrampolim;
    public CharacterMoviment characterMoviment;

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
