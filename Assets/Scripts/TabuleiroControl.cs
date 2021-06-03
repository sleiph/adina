using UnityEngine;

public class TabuleiroControl : MonoBehaviour
{
    // variaveis
    public GameObject platPrefab;
    public GameObject jogPrefab;

    private bool isAliadoTurno = true;
    
    public int[] tamanhoTabuleiro = new int[2];
    Peca[,] tabuleiro;

    public Aliado[] amigos = new Aliado[5];

    public Inimigo[] inimigos = new Inimigo[5];

    // funcoes
    void tabuleiroSpawn(int tamanhoX, int tamanhoZ) {
        tabuleiro = new Peca[tamanhoX, tamanhoZ];

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
        a.setPai(tabuleiro[ a.x, a.z ]);
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
