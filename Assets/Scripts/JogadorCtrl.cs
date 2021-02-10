using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorCtrl : MonoBehaviour
{
    // variaveis
    /// o quão longe um jogador pode ir
    public int mobilidade;

    /// controle de selecao
    public bool isSelectado;
    bool m_isSelectado = false;

    /// o sprite do jogador
    Material sprito;
    
    /// as texturas do sprite do jogador
    public Texture normalTex;
    public Texture seleTex;

    //funcoes
    void Start()
    {
        sprito = transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
    }

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