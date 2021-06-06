using UnityEngine;

public class Plataforma
{
    // variaveis do objeto
    private Vector3 posicao { get; set; }

    private int estado { get; set; }

    private GameObject corpo { get; set; }
    private Material topo;

    private Plataforma NO, ND, O, D, SO, SD;

    private Jogador filho { get; set; }

    // construtor
    Plataforma(Vector3 pos, GameObject c)
    {
        posicao = pos;
        corpo = c;
        topo = corpo.GetComponent<MeshRenderer>().materials[2];
        setEstado(0);
        NO=null; ND=null; O=null; D=null; SO=null; SD=null;
    }

    public GameObject getCorpo() {
        return corpo;
    }
    public void setCorpo(GameObject o) {
        corpo = o;
        topo = corpo.GetComponent<MeshRenderer>().materials[2];
    }

    public void setEstado(int e) {
        switch (e) {
            case 0:     /// 0 inicial
                topo.SetColor("_Color", new Color(110f/255f, 230f/255f, 120f/255f) );
                break;
            case 1:     /// 1 selecionado
                topo.SetColor("_Color", new Color(45f/255f, 166f/255f, 81f/255f) );
                break;
            case 2:     /// 2 disponivel
                topo.SetColor("_Color", new Color(250f/255f, 195f/255f, 0f/255f) );
                break;
            case 3:     /// 3 ocupado
                topo.SetColor("_Color", new Color(126f/255f, 25f/255f, 30f/255f) );
                break;
        }
        estado = e;
    }
    
}
