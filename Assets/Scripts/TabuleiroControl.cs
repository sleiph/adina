using UnityEngine;

public class Peca
{
    // variaveis do objeto
    private int x;
    private int z;

    // construtor
    public Peca(int xPos, int zPos)
    {
        x = xPos;
        z = zPos;
    }

    public Vector3 getPos()
    {
        return new Vector3(x, 0, z);
    }
}

public class Jogador
{
    // variaveis do objeto
    private float x;
    private float z;

    // construtor
    public Jogador(float xPos, float zPos)
    {
        x = xPos;
        z = zPos;
    }


}

public class Aliado : Jogador
{
    // variaveis do objeto
    private static int importancia;

    public Aliado(float xPos, float zPos) : base(xPos, zPos)
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

    public Inimigo(float xPos, float zPos) : base(xPos, zPos)
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

    // funcoes
    void Start()
    {
        for (int i=0; i<10; i++) {
            for (int j=0; j<10; j++) {
                Peca peca = new Peca(i, j);
                tabuleiro[i, j] = peca;
                Instantiate(plataforma, peca.getPos(), Quaternion.identity);
            }
        }
        Debug.Log(tabuleiro[1, 4].getPos());
    }

    void Update()
    {
        
    }
}
