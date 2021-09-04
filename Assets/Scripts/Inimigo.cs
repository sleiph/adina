using System;
using UnityEngine;

[Serializable]
public class Inimigo : Jogador
{
    // variaveis do objeto
    private static int importancia { get; set; }

    Inimigo(
        string n, Vector3 pos, Sprite spr, int alc
    ) : base(n, pos, spr)
    {
        
    }

    static Inimigo()
    {
        importancia = 0;
    }

    public override void setCorpo(GameObject o)
    {
        this.corpo = o;
        corpo.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
    }

}
