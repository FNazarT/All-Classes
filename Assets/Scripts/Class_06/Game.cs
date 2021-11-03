using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject Piedra;
    public GameObject Papel;
    public GameObject Tijera;

    public void BtnAction()
    {
        float numero = Random.Range(1, 4);

        if (numero == 1)
        {
            Piedra.SetActive(true);
            Papel.SetActive(false);
            Tijera.SetActive(false);
        }
        else if (numero == 2)
        {
            Piedra.SetActive(false);
            Papel.SetActive(true);
            Tijera.SetActive(false);
        }
        else if (numero == 3)
        {
            Piedra.SetActive(false);
            Papel.SetActive(false);
            Tijera.SetActive(true);
        }
    }
}
