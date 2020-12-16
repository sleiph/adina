using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaSpawner : MonoBehaviour
{
    // referencias
    public GameObject platPrefab;
    private Vector3 jPos;
    private Transform tabuleiro;

    // funcoes
    public void SpawnTabuleiro() {
        tabuleiro = transform.GetChild(0);
        foreach (Transform p in tabuleiro.transform)
            GameObject.Destroy(p.gameObject);

        jPos = transform.GetChild(1).position;
        int jX = (int)jPos.x,
            jZ = (int)jPos.z;
        Quaternion rotacao = Quaternion.Euler(-90, 0, 0);

        for (int i=jX-4; i<=jX+4; i++) {
            for (int j=jZ-4; j<=jZ+4; j++) {
                GameObject plataforma = Instantiate(platPrefab, new Vector3(i, 0, j), rotacao);
                plataforma.transform.parent = tabuleiro;
            }
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        SpawnTabuleiro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
