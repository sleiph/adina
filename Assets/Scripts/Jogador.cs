using UnityEngine;

public class Jogador
{
    // variaveis do objeto
    public string nome;
    public Vector3 posicao;
    public Sprite sprite;
    private GameObject corpo;
    private Plataforma pai;
    
    // construtor
    public Jogador(string n, Vector3 pos, Sprite spr)
    {
        nome = n;
        posicao = pos;
        sprite = spr;
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

    // getters n setters
    public Vector3 getPos()
    {
        return posicao;
    }
    public void setPos(Vector3 pos)
    {
        posicao = pos;
    }

    public GameObject getCorpo()
    {
        return corpo;
    }
    public void setCorpo(GameObject o)
    {
        corpo = o;
    }

    public Plataforma getPai()
    {
        return pai;
    }
    public void setPai(Plataforma p)
    {
        pai = p;
    }

    public Sprite getSprite() {
        return sprite;
    }
    public void setSprite() {
        corpo.transform.GetChild(0)
            .GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
