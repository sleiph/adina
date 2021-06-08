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

    // estados
    public void Deselecionar() {
        isSelecionado = false;
        pai.setEstado(0);
    }  
    public void Selecionar() {
        isSelecionado = true;
        pai.setEstado(1);
    }    
}
