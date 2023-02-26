using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{

    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;
    public int daño;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiempoSiguienteDaño -= Time.deltaTime;
            if (tiempoSiguienteDaño <= 0)
            {
                collision.GetComponent<CombateJugador>().TomarDaño(daño);
                tiempoSiguienteDaño = tiempoEntreDaño;
            }
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
