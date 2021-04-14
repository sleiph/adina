using UnityEngine;

public class Peca
{
    // variaveis do objeto
    private float x;
    private float z;
    private int estado = 0;
    private GameObject corpo;

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

    public int getEstado() {
        return estado;
    }
    public void setEstado(int e) {
        estado = e;
    }

    public GameObject getCorpo() {
        return corpo;
    }
    public void setCorpo(GameObject o) {
        corpo = o;
    }
}

public class Jogador
{
    // variaveis do objeto
    private float x;
    private float z;
    private int estado = 0;
    private int alcance;
    private Material sprite;

    // construtor
    public Jogador(float xPos, float zPos, int alc)
    {
        x = xPos;
        z = zPos;
        alcance = alc;
    }

    public int getEstado() {
        return estado;
    }
    public void setEstado(int e) {
        estado = e;
    }

    public Material getMaterial() {
        return sprite;
    }
    public void setMaterial(Material m) {
        sprite = m;
    }
}

public class Aliado : Jogador
{
    // variaveis do objeto
    private static int importancia;

    public Aliado(float xPos, float zPos, int alc) : base(xPos, zPos, alc)
    {

    }

    static Aliado()
    {
        importancia = 1;
    }

    
}

public class Inimigo : Jogador
{
    // variaveis do objeto
    private static int importancia;

    public Inimigo(float xPos, float zPos, int alc) : base(xPos, zPos, alc)
    {
        
    }

    static Inimigo()
    {
        importancia = 0;
    }

    
}

public class TabuleiroControl : MonoBehaviour
{
    // variaveis
    public GameObject plataforma;

    Peca[,] tabuleiro = new Peca[10,10];
    Aliado[] amigos = new Aliado[5];
    Inimigo[] inimigos = new Inimigo[5];

    Aliado protagonista = new Aliado(4, 4, 2);
    Aliado amiga = new Aliado(8, 2, 2);

    // funcoes
    void Start()
    {
        for (int i=0; i<10; i++) {
            for (int j=0; j<10; j++) {
                Peca peca = new Peca(i, j);
                if (j%2!=0) {
                    peca.setPos(i-0.5f, j);
                }
                GameObject myPeca = Instantiate(plataforma, peca.getPos(), Quaternion.identity);
                myPeca.transform.parent = this.transform;
                peca.setCorpo(myPeca);
                tabuleiro[i, j] = peca;
            }
        }
        Debug.Log(tabuleiro[2, 7].getCorpo().transform.position);

        
    }

    void Update()
    {
        
    }
}
