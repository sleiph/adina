using UnityEngine;

public class Jogador
{
    // variaveis do objeto
    public string nome;
    public Sprite sprite;
    public Transform corpo { get; set; }
    public Plataforma pai { get; set; }
    
    // construtor
    public Jogador(string nome, Sprite sprite, Transform corpo, Plataforma pai)
    {
        this.nome = nome;
        setSprite(sprite);
        this.corpo = corpo;
        setPai(pai);
    }

    public override string ToString()
    {
        return nome;
    }

    public string getNome() {
        return nome;
    }
    public void setNome(string n) {
        nome = n;
    }

    public Sprite getSprite() {
        return sprite;
    }
    public void setSprite(Sprite sprite) {
        this.sprite = sprite;
        //corpo.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void setPai(Plataforma pai)
    {
        this.pai.setFilho(null);
        this.pai = pai;
        this.pai.setFilho(corpo);
        corpo.transform.SetParent( pai.corpo );
        corpo.transform.localPosition = new Vector3(0, 0, 0);
    }

}
