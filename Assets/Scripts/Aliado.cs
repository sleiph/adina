using System;
using UnityEngine;

[Serializable]
public class Aliado : Jogador
{
    // variaveis do objeto
    public int alcance;
    private int importancia { get; set; }

    Aliado(
        int xPos, int zPos, int alc, Material spr
    ) : base(xPos, zPos, spr)
    {
        alcance = alc;
    }

    public void Deselecionar() {
        pai.setDeselecionado();
    }  
    public void Selecionar() {
        pai.setSelecionado();
    }    
}
