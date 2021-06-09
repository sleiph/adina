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
        tabuleiro = setTabuleiro(raiz, tabuleiro, tamanho);
    }

    public Dictionary<Vector3, Plataforma> setTabuleiro(
        Plataforma p, Dictionary<Vector3, Plataforma> tabuleiroHash, int t
    ) {
        if (t == 0)
            return tabuleiroHash;
        
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
            p.NE = nova;
            tabuleiroHash[posNE] = nova;
        }
        else
            p.NE = tabuleiroHash[posNE];
        setTabuleiro(p.NE, tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posD)) {
            Plataforma nova = new Plataforma(posD);
            p.D = nova;
            tabuleiroHash[posD] = nova;
        }
        else
            p.D = tabuleiroHash[posD];
        setTabuleiro(p.D, tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posSE)) {
            Plataforma nova = new Plataforma(posSE);
            p.SE = nova;
            tabuleiroHash[posSE] = nova;
        }
        else
            p.SE = tabuleiroHash[posSE];
        setTabuleiro(p.SE, tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posND)) {
            Plataforma nova = new Plataforma(posND);
            p.ND = nova;
            tabuleiroHash[posND] = nova;
        }
        else
            p.ND = tabuleiroHash[posND];
        setTabuleiro(p.ND, tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posE)) {
            Plataforma nova = new Plataforma(posE);
            p.E = nova;
            tabuleiroHash[posE] = nova;
        }
        else
            p.ND = tabuleiroHash[posE];
        setTabuleiro(p.ND, tabuleiroHash, t-1);

        if (!tabuleiroHash.ContainsKey(posSD)) {
            Plataforma nova = new Plataforma(posSD);
            p.SD = nova;
            tabuleiroHash[posSD] = nova;
        }
        else
            p.SD = tabuleiroHash[posSD];
        setTabuleiro(p.SD, tabuleiroHash, t-1);

        return tabuleiroHash;
    }

}
