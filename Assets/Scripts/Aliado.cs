using System;
using UnityEngine;

[Serializable]
public class Aliado : Jogador
{
    // variaveis do objeto
    public int alcance;
    private int importancia { get; set; }

    Aliado(
        string n, Vector3 pos, Sprite spr, int alc
    ) : base(n, pos, spr)
    {
        alcance = alc;
    }
 
}
