using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;
    public event EventHandler MuerteEnemigo;
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            Muerte();
            
        }
        
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        MuerteEnemigo?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }
    
}
