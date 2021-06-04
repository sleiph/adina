using System;
using UnityEngine;

[Serializable]
public class Aliado : Jogador
{
    // variaveis do objeto
    public int alcance;
    private int importancia { get; set; }
    private bool isSelecionado { get; set; }

    Aliado(
        int xPos, int zPos, int alc, Material spr
    ) : base(xPos, zPos, spr)
    {
        alcance = alc;
        isSelecionado = false;
    }

    // estado
    public void Deselecionar() {
        isSelecionado = false;
        pai.Inicial();
    }  
    public void Selecionar() {
        isSelecionado = true;
        pai.Selecionado();
    }    
}
