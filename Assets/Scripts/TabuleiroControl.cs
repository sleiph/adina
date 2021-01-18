using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabuleiroControl : MonoBehaviour
{
    // variaveis
    public Transform[] jogadores;
    Transform jogSelec;

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

                // pega todos os filhos do tabuleiro
                foreach (Transform plat in transform) {
                    plat.transform.GetComponent<PlataformaCtrl>().isOver = false;
                }

                hitInfo.transform.GetComponent<PlataformaCtrl>().isOver = true;
            }
            else if (hitInfo.transform.gameObject.tag == "Player") {

                // pega todos os elementos registrados na variável jogadores
                foreach (Transform j in jogadores) {
                    j.transform.parent.GetComponent<PlataformaCtrl>().isOver = false;
                }

                hitInfo.transform.parent.parent.GetComponent<PlataformaCtrl>().isOver = true;
            }
        }

        // se clicar
        if (Input.GetMouseButtonDown(0))
        {
            if (hit) {
                if (hitInfo.transform.gameObject.tag == "plataforma") {
                    jogSelec.parent = hitInfo.transform;
                    jogSelec.transform.position = hitInfo.transform.position;

                    foreach (Transform plat in transform) {
                        plat.GetComponent<PlataformaCtrl>().isSelectado = false;
                        plat.GetComponent<MeshCollider>().enabled = false;
                    }

                    foreach (Transform jogador in jogadores) {
                        jogador.GetChild(0).GetComponent<MeshCollider>().enabled = true;
                    }

                    hitInfo.transform.GetComponent<PlataformaCtrl>().isSelectado = true;
                }
                if (hitInfo.transform.gameObject.tag == "Player") {
                    jogSelec = hitInfo.transform.parent;

                    foreach (Transform jogador in jogadores) {
                        jogador.transform.parent.GetComponent<PlataformaCtrl>().isSelectado = false;
                        jogador.GetChild(0).GetComponent<MeshCollider>().enabled = false;
                    }

                    foreach (Transform plat in transform) {
                        plat.GetComponent<MeshCollider>().enabled = true;
                    }

                    hitInfo.transform.parent.parent.GetComponent<PlataformaCtrl>().isSelectado = true;
                }
            }
        } 
    }
}