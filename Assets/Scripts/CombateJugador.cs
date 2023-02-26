using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] int vida;
    [SerializeField] int maximoVida;
    public event EventHandler MuerteJugador;
    // Start is called before the first frame update
    void Start()
    {
        vida = maximoVida;
    }

    public void TomarDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public void curar(int curacion)
    {
        if ((vida + curacion) > maximoVida)
        {
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }
    }
}
