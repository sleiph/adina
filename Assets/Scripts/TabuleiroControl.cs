using UnityEngine;

class Peca
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

class Jogador
{
    // variaveis do objeto
    private float x;
    private float z;
    private int estado = 0;
    private int alcance;
    private GameObject corpo;
    private Peca pai;
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

    public Vector3 getPos()
    {
        return new Vector3(x, 0, z);
    }
    public void setPos(float xPos, float zPos) {
        x = xPos;
        z = zPos;
    }

    public float getX()
    {
        return x;
    }
    public float getZ()
    {
        return z;
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
    public void setMaterial(Material m) {
        Material[] tempMats = {m};
        corpo.transform.GetChild(0)
            .GetComponent<Renderer>().materials = tempMats;
        sprite = m;
    }
}

class Aliado : Jogador
{
    // variaveis do objeto
    private int importancia;

    public Aliado(float xPos, float zPos, int alc) : base(xPos, zPos, alc)
    {

    }

    public void Selecionar() {
        //this.getCorpo().transform.parent
    }    
}

class Inimigo : Jogador
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
    public int[] tamanhoTabuleiro = new int[2];
    public GameObject platPrefab;
    public GameObject jogPrefab;
    public Material[] matAliados = new Material[10];

    private bool isAliadoTurno = true;
    private int nAliados = 0;
    private int nMigos = 0;

    Peca[,] tabuleiro = new Peca[10,10];
    Aliado[] amigos = new Aliado[5];
    Inimigo[] inimigos = new Inimigo[5];

    // funcoes
    void tabuleiroSpawn(int tamanhoX, int tamanhoZ) {
        for (int i=0; i<tamanhoX; i++) {
            for (int j=0; j<tamanhoZ; j++) {
                Peca peca = new Peca(i, j);
                if (j%2!=0) {
                    peca.setPos(i-0.5f, j);
                }
                GameObject myPeca = Instantiate(platPrefab, peca.getPos(), Quaternion.identity);
                myPeca.transform.parent = this.transform;
                peca.setCorpo(myPeca);
                tabuleiro[i, j] = peca;
            }
        }
    }

    void aliadoSpawn(float xPos, float zPos, int alcance) {
        Aliado aliado = new Aliado(xPos, zPos, alcance);

        GameObject myAliado = Instantiate(
            jogPrefab,
            aliado.getPos(),
            Quaternion.identity
        );

        aliado.setCorpo(myAliado);
        aliado.setPai(tabuleiro[ (int)xPos, (int)zPos ]);
        aliado.setMaterial(matAliados[nAliados]);

        amigos[nAliados] = aliado;

        nAliados++;
    }

    void Start()
    {
        tabuleiroSpawn(tamanhoTabuleiro[0], tamanhoTabuleiro[1]);

        aliadoSpawn(7, 4, 1);
        aliadoSpawn(5, 2, 3);
    }

    void Update()
    {
        
    }
}
