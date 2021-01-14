using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platControl : MonoBehaviour
{
    // variaveis
    public bool isSelectado;
    bool m_isSelectado = false;

    public bool isOver;
    bool m_isOver = false;

    Material topo;

    public Color normalCor;
    public Color overCor;
    public Color seleCor;

    // Start is called before the first frame update
    void Start()
    {
        topo = GetComponent<MeshRenderer>().materials[2];
    }

    // Update is called once per frame
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
