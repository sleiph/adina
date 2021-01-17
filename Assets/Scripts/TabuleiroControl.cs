using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabuleiroControl : MonoBehaviour
{
    // variaveis
    public Transform[] jogadores;
    public Transform jogSelec;

    // funcoes
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // se passar o mouse
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit) {
            if (hitInfo.transform.gameObject.tag == "plataforma") {
                foreach (Transform p in transform) {
                    p.transform.GetComponent<platControl>().isOver = false;
                }

                hitInfo.transform.GetComponent<platControl>().isOver = true;
            }
            else if (hitInfo.transform.gameObject.tag == "Player") {
                foreach (Transform p in jogadores) {
                    p.transform.parent.transform.GetComponent<platControl>().isOver = false;
                }

                hitInfo.transform.parent.parent.GetComponent<platControl>().isOver = true;
            }
        }

        // se clicar
        if (Input.GetMouseButtonDown(0))
        {
            if (hit) {
                if (hitInfo.transform.gameObject.tag == "plataforma") {
                    jogSelec.transform.position = hitInfo.transform.position;

                    foreach (Transform p in transform) {
                        p.transform.GetComponent<platControl>().isSelectado = false;
                    }

                    hitInfo.transform.GetComponent<platControl>().isSelectado = true;
                }
                if (hitInfo.transform.gameObject.tag == "Player") {

                    foreach (Transform p in jogadores) {
                        p.transform.parent.transform.GetComponent<platControl>().isSelectado = false;
                    }

                    hitInfo.transform.parent.parent.transform.GetComponent<platControl>().isSelectado = true;
                }
            }
        } 
    }
}