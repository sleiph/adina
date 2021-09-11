using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTabuleiro : MonoBehaviour
{
    private Dictionary<Vector3, Plataforma> tabuleiro;

    public Transform[] aliados;

    public Transform[] inimigos;

    public bool isAliadoTurno;

    private Aliado selecionado;
    private Inimigo selecionadoInimigo;

    private List<Plataforma> possiveis;

    void selecionarAliado (Transform alvo) {
        selecionadoInimigo = null;
        //loopa pelos aliados até achar o corpo clicado
        foreach (Transform a in aliados) {
            if (alvo.parent == a) {
                selecionado = alvo.parent.GetComponent<myAliado>().aliado;
                break;
            }
        }
        
        // se o jogador clicou em uma peça
        if (selecionado != null) {
            possiveis = selecionado.setPossiveis(tabuleiro);
            //colore as possibilidades
            foreach (Plataforma p in possiveis) {
                p.selecionar();
            }
        }
    }

    void selecionarInimigo (Transform alvo) {
        selecionado = null;
        //loopa pelos aliados até achar o corpo clicado
        foreach (Transform i in inimigos) {
            if (alvo.parent == i) {
                selecionadoInimigo = alvo.parent.GetComponent<myInimigo>().inimigo;
                break;
            }
        }
        
        // se o jogador clicou em uma peça
        if (selecionadoInimigo != null) {
            possiveis = selecionadoInimigo.setPossiveis(tabuleiro);
            //colore as possibilidades
            foreach (Plataforma p in possiveis) {
                p.selecionarInimigo();
            }
        }
    }

    void selecionarPlataforma (Transform alvo) {
        Plataforma temp = tabuleiro[alvo.position];
        
        if (temp.filho == null) {
            foreach (Plataforma p in possiveis) {
                if (temp == p) {
                    selecionado.setPai( temp );
                    break;
                }
            }
        }
        selecionado = null;
    }

    void Start() {
        tabuleiro = new Dictionary<Vector3, Plataforma>();
        foreach (Transform filho in transform) {
            myPlataforma temp = filho.GetComponent<myPlataforma>();
            temp.encorporar();
            tabuleiro[filho.position] = temp.plataforma;
        }

        foreach (Transform aliado in aliados) {
            aliado.GetComponent<myAliado>().encorporar();
        }

        foreach (Transform inimigo in inimigos) {
            inimigo.GetComponent<myInimigo>().encorporar();
        }

        selecionado = null;
        possiveis = null;
    }

    void Update() {
        //turno do jogador
        if (isAliadoTurno) {
            if (Input.GetMouseButtonDown(0)) {
                //cria o um raio da camera pra onde o mouse foi clicado
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(
                    Camera.main.ScreenPointToRay(Input.mousePosition),
                    out hitInfo
                );

                if (hit) {
                    if (possiveis != null) {
                        foreach (Plataforma p in possiveis) {
                            p.deselecionar();
                        }
                    }

                    if ( hitInfo.transform.gameObject.tag == "Player" ) {
                        selecionarAliado(hitInfo.transform);
                    }
                    else if (hitInfo.transform.gameObject.tag == "inimigo") {
                        if (selecionadoInimigo == null)
                            selecionarInimigo(hitInfo.transform);
                        else
                            selecionadoInimigo = null;
                    }
                    else if (hitInfo.transform.gameObject.tag == "plataforma") {
                        if (selecionado != null && selecionadoInimigo == null) {
                            selecionarPlataforma(hitInfo.transform);
                        }
                        else
                            selecionadoInimigo = null;
                    }
                    else {
                        selecionado = null;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Tab)) {
                Debug.Log("colé man");
            }
        }
        //turno do adversário
        else {

        }
    }
}
