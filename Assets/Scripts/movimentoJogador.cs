using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoJogador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            if (position.z < 7) {
                position.z++;
                this.transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            if (position.z > 0) {
                position.z--;
                this.transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            if (position.x < 7) {
                position.x++;
                this.transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            if (position.x > 0) {
                position.x--;
                this.transform.position = position;
            }
        }
    }
}
