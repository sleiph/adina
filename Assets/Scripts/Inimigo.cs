using System;
using UnityEngine;

[Serializable]
public class Inimigo : Jogador
{
    // variaveis do objeto
    private static int importancia { get; set; }

    Inimigo(
        int xPos, int zPos, int alc, Material spr
    ) : base(xPos, zPos, alc, spr)
    {
        
    }

    static Inimigo()
    {
        importancia = 0;
    }

}
