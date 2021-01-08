using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platControl : MonoBehaviour
{
    // variaveis
    public bool isSelectado = false;
    bool m_isSelectado = false;

    public Material[] selecMat;
    public Material[] deselecMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectado != m_isSelectado) {
            if (isSelectado)
                GetComponent<MeshRenderer>().materials = selecMat;
            else
                GetComponent<MeshRenderer>().materials = deselecMat;
            m_isSelectado = isSelectado;
        }
    }
}
