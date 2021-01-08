using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoMouse : MonoBehaviour
{
    // variaveis

    // funcoes
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit) {
                if (hitInfo.transform.gameObject.tag == "plataforma") {
                    hitInfo.transform.GetComponent<platControl>().isSelectado = true;
                }
            }
        } 
    }
}