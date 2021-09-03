using UnityEngine;
using System.Collections.Generic;

public class Tabuleiro
{
    private int tamanho;

    public Dictionary<Vector3, Plataforma> tabuleiro;

    public HashSet<Plataforma> selecao;

    public Tabuleiro(int t) {
        tamanho = t;
        tabuleiro = new Dictionary<Vector3, Plataforma>();
        selecao = null;
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

    public void setTabuleiro(
        HashSet<Plataforma> set, Plataforma raiz, int n
    ) {
        if (n == 0)
            return;

        Vector3 posNE = new Vector3(raiz.posicao.x, raiz.posicao.y+1, raiz.posicao.z-1);
        Vector3 posD = new Vector3(raiz.posicao.x+1, raiz.posicao.y-1, raiz.posicao.z);
        Vector3 posSE = new Vector3(raiz.posicao.x-1, raiz.posicao.y, raiz.posicao.z+1);
        Vector3 posND = new Vector3(raiz.posicao.x+1, raiz.posicao.y, raiz.posicao.z-1);
        Vector3 posE = new Vector3(raiz.posicao.x-1, raiz.posicao.y+1, raiz.posicao.z);
        Vector3 posSD = new Vector3(raiz.posicao.x, raiz.posicao.y-1, raiz.posicao.z+1);

        if (tabuleiro.ContainsKey(posNE)) {
            set.Add(tabuleiro[posNE]);
            setTabuleiro(set, tabuleiro[posNE], n-1);
        }
        if (tabuleiro.ContainsKey(posD)) {
            set.Add(tabuleiro[posD]);
            setTabuleiro(set, tabuleiro[posD], n-1);
        }
        if (tabuleiro.ContainsKey(posSE)) {
            set.Add(tabuleiro[posSE]);
            setTabuleiro(set, tabuleiro[posSE], n-1);
        }
        if (tabuleiro.ContainsKey(posND)) {
            set.Add(tabuleiro[posND]);
            setTabuleiro(set, tabuleiro[posND], n-1);
        }
        if (tabuleiro.ContainsKey(posE)) {
            set.Add(tabuleiro[posE]);
            setTabuleiro(set, tabuleiro[posE], n-1);
        }
        if (tabuleiro.ContainsKey(posSD)) {
            set.Add(tabuleiro[posSD]);
            setTabuleiro(set, tabuleiro[posSD], n-1);
        }

        return ;
    }

    public void colorePlataformas() {
        //plataformas[0].topo.SetColor("_Color", new Color(45f/255f, 166f/255f, 81f/255f) );
        foreach (Plataforma p in selecao) {
            switch (p.getEstado()) {
                case 0:     /// 0 disponivel
                    p.topo.SetColor("_Color", new Color(250f/255f, 195f/255f, 0f/255f) );
                    break;
                case 1:     /// 1 ocupado
                    p.topo.SetColor("_Color", new Color(126f/255f, 25f/255f, 30f/255f) );
                    break;
            }
        }
    }
    public void descolorePlataformas() {
        foreach (Plataforma p in selecao) {
            p.topo.SetColor("_Color", new Color(60f/255f, 240f/255f, 75f/255f) );
        }
    }
}
