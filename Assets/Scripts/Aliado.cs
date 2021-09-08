using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Aliado : Jogador
{
    // variaveis do objeto
    public Vector3[] movimentos;

    public Aliado(
        string nome, Sprite sprite, Transform corpo, Plataforma pai,
        Vector3[] movimentos
    ) : base(nome, sprite, corpo, pai)
    {
        this.movimentos = movimentos;
    }

    public Vector3[] getMovimentos() {
        return movimentos;
    }
    public void setMovimentos(Vector3[] movimentos) {
        this.movimentos = movimentos;
    }

    public List<Plataforma> setPossiveis(Dictionary<Vector3, Plataforma> tabuleiro) {
        List<Plataforma> temp = new List<Plataforma>();

        foreach (Vector3 m in movimentos) {
            if (tabuleiro.ContainsKey(pai.posicao - m))
                temp.Add(tabuleiro[pai.posicao - m]);
        }

        return temp;
    }

}
