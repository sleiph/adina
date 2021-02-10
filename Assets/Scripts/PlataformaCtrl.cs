using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCtrl : MonoBehaviour
{
    // variaveis
    /// controle de selecao
    public bool isSelectado;
    bool m_isSelectado = false;

    /// controle de hover do mouse
    public bool isOver;
    bool m_isOver = false;

    /// a textura da parte de cima da plataforma
    Material topo;

    /// as cores de cada fase da plataforma
    public Color normalCor;
    public Color overCor;
    public Color seleCor;
    public Color possiCor;

    // funcoes
    void Start()
    {
        topo = GetComponent<MeshRenderer>().materials[2];
    }

    void Update()
    {
        // se o mouse estiver sobre o piso
        if (isOver != m_isOver && !isSelectado) {
            if (isOver) {
                topo.SetColor("_Color", overCor);
            }
            else {
                topo.SetColor("_Color", normalCor);
            }
            m_isOver = isOver;
        }

        // se o mouse for clicado
        if (isSelectado != m_isSelectado) {
            if (isSelectado) {
                topo.SetColor("_Color", seleCor);
            }
            else {
                topo.SetColor("_Color", normalCor);
            }
            m_isSelectado = isSelectado;
        }
    }
}
