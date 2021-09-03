using System;
using System.Collections.Generic;
using UnityEngine;

public class TabuleiroControl : MonoBehaviour
{
    // variaveis
    public GameObject jogadoresPrefab;

    public Aliado[] aliados = new Aliado[5];

    public Inimigo[] inimigos = new Inimigo[5];

    public GameObject plataformaPrefab;
    
    public int tamanhoTabuleiro;
    Tabuleiro myTabuleiro;

    Aliado selecionado = null;

    private bool isAliadoTurno = true;

    // funcoes
    void tabuleiroSpawn() {
        myTabuleiro = new Tabuleiro(tamanhoTabuleiro);

        foreach(KeyValuePair<Vector3, Plataforma> p in myTabuleiro.tabuleiro)
        {
            GameObject myPlataforma = Instantiate(
                plataformaPrefab, p.Key, Quaternion.Euler(new Vector3(55, 45, 0))
            );
            myPlataforma.transform.parent = this.transform;
            p.Value.setCorpo(myPlataforma);
        }
    }

    void aliadoSpawn() {
        foreach (Aliado a in aliados) {
            GameObject myAliado = Instantiate(
                jogadoresPrefab,
                a.getPos(),
                new Quaternion(0,0,0,0),
                myTabuleiro.tabuleiro[a.getPos()].getCorpo().transform
            );
            
            a.setCorpo(myAliado);
            a.setPai(myTabuleiro.tabuleiro[a.getPos()]);
            a.setSprite();

        }
    }

    void selecionarPeca () {
        //criao um raio da camera pra onde o mouse foi clicado
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            out hitInfo
        );

        //seleciona o pai do sprite clicado
        if (hit) {
            if (myTabuleiro.selecao != null)
                myTabuleiro.descolorePlataformas();

            if ( hitInfo.transform.gameObject.tag == "Player" ) {
                //loopa pelos aliados até achar o corpo clicado
                foreach (Aliado a in aliados) {
                    if (hitInfo.transform.parent.gameObject == a.getCorpo()) {
                        selecionado = a;
                        break;
                    }
                }

                // se o jogador clicou em uma peça
                if (selecionado != null) {
                    myTabuleiro.selecao = plataformasPossiveis(selecionado);
                    //colore as possibilidades
                    myTabuleiro.colorePlataformas();
                }
            }
            else if (hitInfo.transform.gameObject.tag == "plataforma") {
                if (selecionado != null) {
                    Plataforma temp = myTabuleiro.tabuleiro[hitInfo.transform.position];
                    if (temp.getEstado()==0)
                        selecionado.setPai( temp );
                }
            }
            else
                selecionado = null;
        }
    }

    public HashSet<Plataforma> plataformasPossiveis(Aliado a) {
        HashSet<Plataforma> temp = new HashSet<Plataforma>();
        temp.Add(a.getPai());

        myTabuleiro.setTabuleiro(temp, a.getPai(), a.alcance);

        return temp;
    }

    void Start()
    {
        tabuleiroSpawn();
        aliadoSpawn();
    }

    void Update()
    {
        //turno do jogador
        if (isAliadoTurno) {
            if (Input.GetMouseButtonDown(0)) {
                selecionarPeca();
            }
        }
        //turno do adversário
        else {

        }
    }
}
