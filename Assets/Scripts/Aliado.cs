using System;
using UnityEngine;

[Serializable]
public class Aliado : Jogador
{
    // variaveis do objeto
    private int importancia { get; set; }

    Aliado(
        int xPos, int zPos, int alc, Material spr
    ) : base(xPos, zPos, alc, spr)
    {

    }

    public void Selecionar() {
        //this.getCorpo().transform.parent
    }    
}
