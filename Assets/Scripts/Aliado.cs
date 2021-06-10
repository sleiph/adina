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
        Vector3 pos, Material spr, int alc
    ) : base(pos, spr)
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
