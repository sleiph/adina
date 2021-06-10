using System;
using UnityEngine;

[Serializable]
public class Inimigo : Jogador
{
    // variaveis do objeto
    private static int importancia { get; set; }

    Inimigo(
        Vector3 pos, Material spr, int alc
    ) : base(pos, spr)
    {
        
    }

    static Inimigo()
    {
        importancia = 0;
    }

}
