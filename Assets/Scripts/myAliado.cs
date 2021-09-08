using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myAliado : MonoBehaviour
{
    public Aliado aliado;

    public void encorporar() {
        aliado.corpo = transform;
        aliado.pai = transform.parent.GetComponent<myPlataforma>().plataforma;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
