using UnityEngine;
using System.Collections.Generic;

public class Tabuleiro
{
    private int tamanho;

    public Dictionary<Vector3, Plataforma> tabuleiro;

    public Tabuleiro(int t) {
        tamanho = t;
        tabuleiro = new Dictionary<Vector3, Plataforma>();
        Plataforma raiz = new Plataforma(new Vector3(0, 0, 0));
        setTabuleiro(raiz, tabuleiro, tamanho);
    }

    public void setTabuleiro(
        Plataforma p, Dictionary<Vector3, Plataforma> tabuleiroHash, int t
    ) {
        if (t == 0)
            return;
        
        if (!tabuleiroHash.ContainsKey(p.posicao)) {
            tabuleiroHash[p.posicao] = p;
        }

        Vector3 posNE = new Vector3(p.posicao.x, p.posicao.y+1, p.posicao.z-1);
        Vector3 posD = new Vector3(p.posicao.x+1, p.posicao.y-1, p.posicao.z);
        Vector3 posSE = new Vector3(p.posicao.x-1, p.posicao.y, p.posicao.z+1);
        Vector3 posND = new Vector3(p.posicao.x+1, p.posicao.y, p.posicao.z-1);
        Vector3 posE = new Vector3(p.posicao.x-1, p.posicao.y+1, p.posicao.z);
        Vector3 posSD = new Vector3(p.posicao.x, p.posicao.y-1, p.posicao.z+1);

        if (!tabuleiroHash.ContainsKey(posNE)) {
            Plataforma nova = new Plataforma(posNE);
            tabuleiroHash[posNE] = nova;
        }
        setTabuleiro(tabuleiroHash[posNE], tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posD)) {
            Plataforma nova = new Plataforma(posD);
            tabuleiroHash[posD] = nova;
        }
        setTabuleiro(tabuleiroHash[posD], tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posSE)) {
            Plataforma nova = new Plataforma(posSE);
            tabuleiroHash[posSE] = nova;
        }
        setTabuleiro(tabuleiroHash[posSE], tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posND)) {
            Plataforma nova = new Plataforma(posND);
            tabuleiroHash[posND] = nova;
        }
        setTabuleiro(tabuleiroHash[posND], tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posE)) {
            Plataforma nova = new Plataforma(posE);
            tabuleiroHash[posE] = nova;
        }
        setTabuleiro(tabuleiroHash[posE], tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posSD)) {
            Plataforma nova = new Plataforma(posSD);
            tabuleiroHash[posSD] = nova;
        }
        setTabuleiro(tabuleiroHash[posSD], tabuleiroHash, t-1);

        return;
    }

}
