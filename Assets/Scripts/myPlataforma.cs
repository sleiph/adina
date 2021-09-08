using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlataforma : MonoBehaviour
{
    public Plataforma plataforma;

    public void encorporar() {
        plataforma.posicao = transform.position;
        plataforma.corpo = transform;
        if (transform.childCount == 0)
        {
            plataforma.filho = null;
        }
        else
        {
            plataforma.filho = transform.GetChild(0);
        }
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
