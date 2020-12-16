using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoJogador : MonoBehaviour
{
    // referencias
    private plataformaSpawner platSpawner;

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
            Vector3 position = this.transform.position;
            //if (position.z < 7) {
                position.z++;
                this.transform.position = position;
            //}
            platSpawner.SpawnTabuleiro();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            //if (position.z > 0) {
                position.z--;
                this.transform.position = position;
            //}
            platSpawner.SpawnTabuleiro();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            //if (position.x < 7) {
                position.x++;
                this.transform.position = position;
            //}
            platSpawner.SpawnTabuleiro();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            //if (position.x > 0) {
                position.x--;
                this.transform.position = position;
            //}
            platSpawner.SpawnTabuleiro();
        }
    }
}
