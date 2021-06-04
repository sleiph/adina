using UnityEngine;

public class Jogador
{
    // variaveis do objeto
    public int x;
    public int z;
    private int estado { get; set; }
    private GameObject corpo;
    public Peca pai;
    public Material sprite;

    // construtor
    Jogador() {}
    public Jogador(int xPos, int zPos, Material spr)
    {
        x = xPos;
        z = zPos;
        sprite = spr;
        estado = 0;
    }

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

    public Peca getPai() {
        return pai;
    }
    public void setPai(Peca p) {
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
