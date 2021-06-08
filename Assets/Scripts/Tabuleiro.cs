using UnityEngine;

public class Tabuleiro
{
    Plataforma raiz;
    private int tamanho;

    Tabuleiro(int t) {
        raiz = null;
        tamanho = t;
    }

    public void Adiciona(Plataforma raiz, Vector3 v, int t) {
        while (t > 0) {
            Plataforma nova = new Plataforma(v);
            if (raiz == null) {
                raiz = nova;
            }
            else {
                if (raiz.NE == null) {
                    nova.SD = raiz;
                    raiz.NE = nova;
                }
                else if (raiz.ND == null) {
                    nova.SE = raiz;
                    nova.E = raiz.NE;
                    raiz.ND = nova;
                    raiz.NE.D = nova;
                }
                else if (raiz.D == null) {
                    nova.E = raiz;
                    nova.NE = raiz.ND;
                    raiz.D = nova;
                    raiz.ND.SD = nova;
                }
                else if (raiz.SD == null) {
                    nova.NE = raiz;
                    nova.ND = raiz.D;
                    raiz.SD = nova;
                    raiz.D.SE = nova;
                }
                else if (raiz.SE == null) {
                    nova.ND = raiz;
                    nova.D = raiz.SD;
                    raiz.SE = nova;
                    raiz.SD.E = nova;
                }
                else if (raiz.E == null) {
                    nova.D = raiz;
                    nova.SD = raiz.SE;
                    nova.ND = raiz.NE;
                    raiz.E = nova;
                    raiz.SE.NE = nova;
                    raiz.NE.SE = nova;
                }
            }
            raiz = raiz.NE;
            t-=1;
        }
    }
}
