using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class plataformaSpawner : MonoBehaviour
{
    // referencias
    public GameObject platPrefab;

    private Transform tabuleiro;

    private List<int[]> matrizTabuleiro = new List<int[]>();

    // funcoes
    public void SpawnPlataforma(int[] pos, Transform mae) {
        bool flag = matrizTabuleiro.Any(p => p.SequenceEqual(pos));
        if (!flag) {
            GameObject plataforma = Instantiate(
                platPrefab,
                new Vector3(pos[0], 0, pos[1]),
                Quaternion.Euler(-90, 0, 0)
            );
            plataforma.transform.parent = mae;
            matrizTabuleiro.Add(pos);
        }
    }
    public void DeletePlataforma(int[] pos) {
        foreach (Transform p in tabuleiro.transform) {
            if (pos[0] == (int)p.position.x && pos[1] == (int)p.position.z) {
                GameObject.Destroy(p.gameObject);
                matrizTabuleiro.RemoveAll(item => pos.SequenceEqual(item));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tabuleiro = transform.GetChild(0);

        Vector3 jPos = transform.GetChild(1).position;
        int posX = (int)jPos.x,
            posZ = (int)jPos.z;

        for (int i=posX-4; i<=posX+4; i++) {
            for (int j=posZ-4; j<=posZ+4; j++) {
                int[] temPos = { i, j };
                SpawnPlataforma( temPos, tabuleiro);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}