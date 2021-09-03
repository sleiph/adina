using UnityEngine;

public class Plataforma
{
    // variaveis do objeto
    public Vector3 posicao { get; set; }

    private int estado;

    private GameObject corpo { get; set; }
    public Material topo { get; set; }

    public Jogador filho { get; set; }

    // construtor
    public Plataforma(Vector3 pos)
    {
        posicao = pos;
        filho = null;
    }
    Plataforma(Vector3 pos, GameObject c)
    {
        posicao = pos;
        corpo = c;
        topo = corpo.GetComponent<MeshRenderer>().materials[2];
        setEstado(0);
        filho = null;
    }

    public override string ToString()
    {
        return posicao.ToString();
    }

    public GameObject getCorpo() {
        return corpo;
    }
    public void setCorpo(GameObject c) {
        corpo = c;
        topo = corpo.GetComponent<MeshRenderer>().materials[2];
    }

    public int getEstado() {
        //0 disponivel
        //1 ocupado
        return estado;
    }
    public void setEstado(int e) {
        estado = e;
    }
    
}
