using System;
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
    public int x;
    public int z;
    private int estado = 0;
    public int alcance;
    private GameObject corpo;
    private Peca pai;
    public Material sprite;

    // construtor
    public Jogador(int xPos, int zPos, int alc, Material spr)
    {
        x = xPos;
        z = zPos;
        alcance = alc;
        sprite = spr;
    }

    public int getEstado() {
        return estado;
    }
    public void setEstado(int e) {
        estado = e;
    }

    public Vector3 getPos()
    {
        if (z%2!=0)
            return new Vector3(x-0.5f, 0, z);
        return new Vector3(x, 0, z);
    }
    public void setPos(int xPos, int zPos) {
        x = xPos;
        z = zPos;
    }

    public int getX()
    {
        return x;
    }
    public int getZ()
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
    public void setMaterial() {
        Material[] tempMats = { sprite };
        corpo.transform.GetChild(0)
            .GetComponent<Renderer>().materials = tempMats;
    }
}

[Serializable]
public class Aliado : Jogador
{
    // variaveis do objeto
    private int importancia;

    public Aliado(
        int xPos, int zPos, int alc, Material spr
    ) : base(xPos, zPos, alc, spr)
    {

    }

    public void Selecionar() {
        //this.getCorpo().transform.parent
    }    
}

[Serializable]
public class Inimigo : Jogador
{
    // variaveis do objeto
    private static int importancia;

    public Inimigo(
        int xPos, int zPos, int alc, Material spr
    ) : base(xPos, zPos, alc, spr)
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
    public GameObject platPrefab;
    public GameObject jogPrefab;

    private bool isAliadoTurno = true;
    
    public int[] tamanhoTabuleiro = new int[2];
    Peca[,] tabuleiro = new Peca[99, 99];

    public Aliado[] amigos = new Aliado[5];

    public Inimigo[] inimigos = new Inimigo[5];

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

    void aliadoSpawn(Aliado a) {

        GameObject myAliado = Instantiate(
            jogPrefab,
            a.getPos(),
            Quaternion.identity
        );

        a.setCorpo(myAliado);
        a.setPai(tabuleiro[ a.getX(), a.getZ() ]);
        a.setMaterial();
    }

    void Start()
    {
        tabuleiroSpawn(tamanhoTabuleiro[0], tamanhoTabuleiro[1]);

        foreach (Aliado a in amigos)
            aliadoSpawn(a);
    }

    void Update()
    {
        
    }
}
