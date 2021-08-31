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
    Plataforma[] possiveis = null;

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

    Aliado selecionarAliado () {
        //criao um raio da camera pra onde o mouse foi clicado
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            out hitInfo
        );

        //seleciona o pai do sprite clicado
        GameObject temp = null;
        Aliado tempa = null;
        if (hit) {
            if (hitInfo.transform.gameObject.tag == "Player") {
                temp = hitInfo.transform.parent.gameObject;                       
            }
        }

        //loopa pelos aliados até achar o corpo clicado
        if (temp != null) {
            foreach (Aliado a in aliados) {
                if (temp == a.getCorpo()) {
                    tempa = a;
                    break;
                }
            }
        }
            
        return tempa;
    }

    public Plataforma[] plataformasPossiveis(Aliado a) {
        Plataforma[] temp = { a.getPai() };

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
                // se ja tiver uma peca selecionada
                if (possiveis != null) {
                    //limpa as possibilidades
                    foreach(Plataforma p in possiveis)
                    {
                        p.setEstado(0);
                    }
                }
                selecionado = selecionarAliado();
                // se o jogador clicou em uma peça
                if (selecionado != null) {
                    possiveis = plataformasPossiveis(selecionado);
                    //colore as possibilidades
                    foreach(Plataforma p in possiveis)
                    {
                        p.setEstado(2);
                    }
                }
            }
        }
        //turno do adversário
        else {

        }
    }
}
