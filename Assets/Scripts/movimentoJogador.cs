using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoJogador : MonoBehaviour
{
    // referencias
    private plataformaSpawner platSpawner;

    private Transform tabuleiro;

    // Start is called before the first frame update
    void Start()
    {
        platSpawner = transform.parent.GetComponent<plataformaSpawner>();
        tabuleiro = transform.parent.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.z++;
            this.transform.position = position;

            int x = (int)position.x;

            // spawnar pra frentemente as plataformas
            for (int j=x-4; j<=x+4; j++) {
                int[] temPos = { j, (int)position.z+4 };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=x-4; j<=x+4; j++) {
                int[] oldPos = { j, (int)position.z-5 };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.z--;
            this.transform.position = position;

            int x = (int)position.x;

            // spawnar pra frentemente as plataformas
            for (int j=x-4; j<=x+4; j++) {
                int[] temPos = { j, (int)position.z-4 };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=x-4; j<=x+4; j++) {
                int[] oldPos = { j, (int)position.z+5 };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;

            int z = (int)position.z;

            // spawnar pra frentemente as plataformas
            for (int j=z-4; j<=z+4; j++) {
                int[] temPos = { (int)position.x+4, j };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=z-4; j<=z+4; j++) {
                int[] oldPos = { (int)position.x-5, j };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;

            int z = (int)position.z;

            // spawnar pra frentemente as plataformas
            for (int j=z-4; j<=z+4; j++) {
                int[] temPos = { (int)position.x-4, j };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=z-4; j<=z+4; j++) {
                int[] oldPos = { (int)position.x+5, j };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
    }
}
