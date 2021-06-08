using System;
using System.Collections.Generic;
using UnityEngine;

public class TabuleiroControl : MonoBehaviour
{
    // variaveis
    public GameObject jogadoresPrefab;
    public GameObject plataformaPrefab;

    private bool isAliadoTurno = true,
                 isPecaSelecionada = false;
    
    public int larguraTabuleiro,
                alturaTabuleiro;

    public Aliado[] aliados = new Aliado[5];

    public Inimigo[] inimigos = new Inimigo[5];

    // funcoes
    void tabuleiroSpawn(int tamanhoX, int tamanhoZ) {
        /*
        tabuleiro = new Plataforma[tamanhoX, tamanhoZ];

        for (int i=0; i<tamanhoX; i++) {
            for (int j=0; j<tamanhoZ; j++) {
                Peca peca = new Peca(i, j);
                if (j%2!=0) {
                    peca.setPos(i-0.5f, j);
                }
                GameObject myPeca = Instantiate(plataformaPrefab, peca.getPos(), Quaternion.identity);
                myPeca.transform.parent = this.transform;
                peca.setCorpo(myPeca);
                tabuleiro[i, j] = peca;
            }
        }*/
    }

    void aliadoSpawn(Aliado a) {
        /*
        GameObject myAliado = Instantiate(
            jogPrefab,
            a.getPos(),
            Quaternion.identity
        );
        
        a.setCorpo(myAliado);
        a.setPai(tabuleiro[ a.x, a.z ]);
        a.setMaterial();
        */
    }

    /*
    List<Peca> GetVizinhos(int x, int z, int alcance) {
        
        List<Peca> vizinhos = new List<Peca>();

        for (int i=x-alcance; i<=x+alcance; i++) {
            if (i>=0 && i<tamanhoTabuleiro[0]) {
                if (z%2 == 0) {
                    if (i==x-alcance) {
                        vizinhos.Add(tabuleiro[i, z]);
                    }
                    else {
                        for (int j=z-alcance; j<=z+alcance; j++) {
                            if (j>=0 && j<tamanhoTabuleiro[1]) {
                                if (i == x && j == z)
                                    continue;
                                else
                                    vizinhos.Add(tabuleiro[i, j]);
                            }
                        }
                    }
                }
                else {
                    if (i==x+alcance) {
                        vizinhos.Add(tabuleiro[i, z]);
                    }
                    else {
                        for (int j=z-alcance; j<=z+alcance; j++) {
                            if (j>=0 && j<tamanhoTabuleiro[1]) {
                                if (i == x && j == z)
                                    continue;
                                else
                                    vizinhos.Add(tabuleiro[i, j]);
                            }
                        }
                    }
                }
            }
        }
        return vizinhos;
        
    }*/

    public void setJogada(Vector3 posicao) {
        /*
        int alcance = 1;
        int x = (int)Math.Ceiling(posicao.x),
            z = (int)posicao.z;

        foreach (Aliado a in amigos) {
            Vector3 temPos = a.getPos();
            if (temPos == posicao) {
                a.Selecionar();
                alcance = a.alcance;
            }
            else
                a.Deselecionar();
        }

        foreach (Peca p in vizinhos) {
            p.Inicial();
        }
        vizinhos = GetVizinhos(x, z, alcance);
        foreach (Peca p in vizinhos) {
            p.Disponivel();
        }*/
    }

    void Start()
    {
        /*
        tabuleiroSpawn(tamanhoTabuleiro[0], tamanhoTabuleiro[1]);

        foreach (Aliado a in amigos)
            aliadoSpawn(a);
        */
    }

    void Update()
    {
        /*
        if (isAliadoTurno) {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(
                Camera.main.ScreenPointToRay(Input.mousePosition),
                out hitInfo
            );

            if (Input.GetMouseButtonDown(0)) {
                if (hit) {
                    if (hitInfo.transform.gameObject.tag == "Player") {
                        setJogada( hitInfo.transform.parent.position );                        
                    }
                }
            }
        }
        */
    }
}
