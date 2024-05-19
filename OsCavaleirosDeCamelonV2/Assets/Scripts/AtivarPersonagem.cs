using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarPersonagem : MonoBehaviour
{
    
    [SerializeField] GameObject[] Character;
    // Start is called before the first frame update
    void Awake() {

      Character[PlayerPrefs.GetInt("PersonagemEscolhido")].SetActive(true);

    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
