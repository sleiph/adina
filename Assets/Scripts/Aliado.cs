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
        string n, Vector3 pos, Sprite spr, int alc
    ) : base(n, pos, spr)
    {
        alcance = alc;
        isSelecionado = false;
    }

    // estados
    public void Deselecionar() {
        isSelecionado = false;
        this.getPai().setEstado(0);
    }  
    public void Selecionar() {
        isSelecionado = true;
        this.getPai().setEstado(1);
    }    
}
