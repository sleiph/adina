using UnityEngine;

public class Peca
{
    // variaveis do objeto
    private float x;
    private float z;

    // estados:
    /// 0 inicial
    /// 1 selecionado
    /// 2 disponivel
    /// 3 ocupado
    private int estado { get; set; }
    private GameObject corpo;
    private Material topo;

    // construtor
    public Peca(float xPos, float zPos)
    {
        x = xPos;
        z = zPos;
    }

    public Vector3 getPos()
    {
        return new Vector3(x, 0, z);
    }
    public void setPos(float xPos, float zPos) {
        x = xPos;
        z = zPos;
    }

    public GameObject getCorpo() {
        return corpo;
    }
    public void setCorpo(GameObject o) {
        corpo = o;
        topo = corpo.GetComponent<MeshRenderer>().materials[2];
        setDeselecionado();
    }

    public void setDeselecionado() {
        estado = 0;
        topo.SetColor("_Color", new Color(110f/255f, 230f/255f, 120f/255f) );
    } 
    public void setSelecionado() {
        estado = 1;
        topo.SetColor("_Color", new Color(45f/255f, 166f/255f, 81f/255f) );
    } 
}
