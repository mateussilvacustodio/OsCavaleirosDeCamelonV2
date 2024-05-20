using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMao : MonoBehaviour
{
    [SerializeField] Rigidbody2D maoRb;
    public bool cair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cair) {

            maoRb.gravityScale = 1.5f;

        } else {

            maoRb.gravityScale = 0;

        }
    }
}
