using System;
using UnityEngine;

[Serializable]
public class Plataforma
{
    // variaveis do objeto
    public Vector3 posicao { get; set; }

    public Transform corpo { get; set; }

    public Transform filho { get; set; }

    // construtor
    public Plataforma(Vector3 posicao, Transform corpo)
    {
        this.posicao = posicao;
        this.corpo = corpo;
        filho = null;
    }
    public Plataforma(Vector3 posicao, Transform corpo, Transform filho)
    {
        this.posicao = posicao;
        this.corpo = corpo;
        this.filho = filho;
    }

    public override string ToString()
    {
        return posicao.ToString();
    }

    public void setFilho(Transform filho) {
        this.filho = filho;
    }

    public void selecionar() {
        // se não tem personagem na plataforma
        if (filho == null) {
            // verde
            corpo.GetComponent<SpriteRenderer>().color = 
                new Color(170f/255f, 221f/255f, 153f/255f);
        }
        else {
            // se o personagem na plataforma form um inimigo
            if (filho.GetComponent<myInimigo>() != null) {
                // amarelo
                corpo.GetComponent<SpriteRenderer>().color = 
                    new Color(255f/255f, 238f/255f, 170f/255f);
            }
            // se for aliado
            else {
                // vermelho
                corpo.GetComponent<SpriteRenderer>().color = 
                    new Color(235f/255f, 170f/255f, 170f/255f);
            }
        }
    }

    public void selecionarInimigo() {
        // se não tem personagem na plataforma
        if (filho == null) {
            // azul
            corpo.GetComponent<SpriteRenderer>().color = 
                new Color(160f/255f, 194f/255f, 255f/255f);
        }
        else {
            // se o personagem na plataforma form um aliado
            if (filho.GetComponent<myAliado>() != null) {
                // amarelo
                corpo.GetComponent<SpriteRenderer>().color = 
                    new Color(255f/255f, 238f/255f, 170f/255f);
            }
            // se for inimigo
            else {
                // vermelho
                corpo.GetComponent<SpriteRenderer>().color = 
                    new Color(235f/255f, 170f/255f, 170f/255f);
            }
        }
    }

    public void deselecionar() {
        corpo.GetComponent<SpriteRenderer>().color = 
            new Color(255f/255f, 255f/255f, 255f/255f);
    }
    
}
