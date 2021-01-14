using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoMouse : MonoBehaviour
{
    // variaveis
    public Transform jogador;

    // funcoes
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // se passar o mouse
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit) {
            if (hitInfo.transform.gameObject.tag == "plataforma") {
                foreach (Transform p in transform) {
                    p.transform.GetComponent<platControl>().isOver = false;
                }

                hitInfo.transform.GetComponent<platControl>().isOver = true;
            }
        }

        // se clicar
        if (Input.GetMouseButtonDown(0))
        {
            if (hit) {
                if (hitInfo.transform.gameObject.tag == "plataforma") {
                    jogador.transform.position = hitInfo.transform.position;

                    foreach (Transform p in transform) {
                        p.transform.GetComponent<platControl>().isSelectado = false;
                    }

                    hitInfo.transform.GetComponent<platControl>().isSelectado = true;
                }
            }
        } 
    }
}