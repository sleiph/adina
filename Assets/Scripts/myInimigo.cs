using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myInimigo : MonoBehaviour
{
    public Inimigo inimigo;

    public void encorporar() {
        inimigo.corpo = transform;
        inimigo.pai = transform.parent.GetComponent<myPlataforma>().plataforma;
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
