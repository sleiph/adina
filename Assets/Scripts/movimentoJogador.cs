using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoJogador : MonoBehaviour
{
    // referencias
    private plataformaSpawner platSpawner;

    public Transform tabuleiro;
    public Transform cam;

    public int arTab;
    public float atraso;

    // Start is called before the first frame update
    void Start()
    {
        platSpawner = transform.parent.GetComponent<plataformaSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // move o jogador
            Vector3 posicaoJogador = this.transform.position;
            posicaoJogador.z++;
            this.transform.position = posicaoJogador;
            // move a camera
            Vector3 posicaoCamera = new Vector3(
                posicaoJogador.x-7.5f,
                posicaoJogador.y+4.5f,
                posicaoJogador.z
            );
            cam.transform.position = Vector3.Lerp(cam.transform.position, posicaoCamera, atraso);

            int x = (int)posicaoJogador.x;

            // spawnar pra frentemente as plataformas
            for (int j=x-arTab; j<=x+arTab; j++) {
                int[] temPos = { j, (int)posicaoJogador.z+arTab };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=x-arTab; j<=x+arTab; j++) {
                int[] oldPos = { j, (int)posicaoJogador.z-(arTab+1) };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 posicaoJogador = this.transform.position;
            posicaoJogador.z--;
            this.transform.position = posicaoJogador;

            Vector3 posicaoCamera = new Vector3(
                posicaoJogador.x-7.5f,
                posicaoJogador.y+4.5f,
                posicaoJogador.z
            );
            cam.transform.position = Vector3.Lerp (cam.transform.position, posicaoCamera, atraso);

            int x = (int)posicaoJogador.x;

            // spawnar pra frentemente as plataformas
            for (int j=x-arTab; j<=x+arTab; j++) {
                int[] temPos = { j, (int)posicaoJogador.z-arTab };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=x-arTab; j<=x+arTab; j++) {
                int[] oldPos = { j, (int)posicaoJogador.z+(arTab+1) };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 posicaoJogador = this.transform.position;
            posicaoJogador.x++;
            this.transform.position = posicaoJogador;

            Vector3 posicaoCamera = new Vector3(
                posicaoJogador.x-7.5f,
                posicaoJogador.y+4.5f,
                posicaoJogador.z
            );
            cam.transform.position = Vector3.Lerp (cam.transform.position, posicaoCamera, atraso);

            int z = (int)posicaoJogador.z;

            // spawnar pra frentemente as plataformas
            for (int j=z-arTab; j<=z+arTab; j++) {
                int[] temPos = { (int)posicaoJogador.x+arTab, j };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=z-arTab; j<=z+arTab; j++) {
                int[] oldPos = { (int)posicaoJogador.x-(arTab+1), j };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 posicaoJogador = this.transform.position;
            posicaoJogador.x--;
            this.transform.position = posicaoJogador;

            Vector3 posicaoCamera = new Vector3(
                posicaoJogador.x-7.5f,
                posicaoJogador.y+4.5f,
                posicaoJogador.z
            );
            cam.transform.position = Vector3.Lerp (cam.transform.position, posicaoCamera, atraso);

            int z = (int)posicaoJogador.z;

            // spawnar pra frentemente as plataformas
            for (int j=z-arTab; j<=z+arTab; j++) {
                int[] temPos = { (int)posicaoJogador.x-arTab, j };
                platSpawner.SpawnPlataforma(
                    temPos,
                    tabuleiro
                );
            }

            // deleta pra trazmente as plataformas
            for (int j=z-arTab; j<=z+arTab; j++) {
                int[] oldPos = { (int)posicaoJogador.x+(arTab+1), j };
                platSpawner.DeletePlataforma( oldPos );
            }
        }
    }
}
