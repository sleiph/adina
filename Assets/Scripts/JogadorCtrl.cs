using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorCtrl : MonoBehaviour
{
    // variaveis
    public bool isSelectado;
    bool m_isSelectado = false;

    Material sprito;
    
    public Texture normalTex;
    public Texture seleTex;

    // Start is called before the first frame update
    void Start()
    {
        sprito = transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        // se o objeto for selecionado
        if (isSelectado != m_isSelectado) {
            if (isSelectado) {
                sprito.SetTexture("_EmissionMap", seleTex);
            }
            else {
                sprito.SetTexture("_EmissionMap", normalTex);
            }
            m_isSelectado = isSelectado;
        }
    }
}