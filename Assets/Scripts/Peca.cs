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
