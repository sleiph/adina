using UnityEngine;

public class Jogador
{
    // variaveis do objeto
    public Vector3 posicao;
    public Material sprite;
    private GameObject corpo;
    private Plataforma pai;
    
    // construtor
    public Jogador(Vector3 pos, Material spr)
    {
        posicao = pos;
        sprite = spr;
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
        corpo.transform.parent = pai.getCorpo().transform;
    }

    public Material getMaterial() {
        return sprite;
    }
    public void setMaterial() {
        Material[] tempMats = { sprite };
        corpo.transform.GetChild(0)
            .GetComponent<Renderer>().materials = tempMats;
    }
}
