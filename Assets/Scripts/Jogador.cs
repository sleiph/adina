using UnityEngine;

public class Jogador
{
    // variaveis do objeto
    public int x;
    public int z;
    private GameObject corpo;
    public Plataforma pai;
    public Material sprite;

    // construtor
    Jogador() {

    }
    public Jogador(int xPos, int zPos, Material spr)
    {
        x = xPos;
        z = zPos;
        sprite = spr;
    }

    // getters n setters
    public Vector3 getPos()
    {
        if (z%2 != 0)
            return new Vector3(x-0.5f, 0, z);
        return new Vector3(x, 0, z);
    }
    public void setPos(int xPos, int zPos) {
        x = xPos;
        z = zPos;
    }

    public GameObject getCorpo() {
        return corpo;
    }
    public void setCorpo(GameObject o) {
        corpo = o;
    }

    public Plataforma getPai() {
        return pai;
    }
    public void setPai(Plataforma p) {
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
