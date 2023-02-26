using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{

    [SerializeField] private float tiempoEntreDa�o;
    private float tiempoSiguienteDa�o;
    public int da�o;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tiempoSiguienteDa�o -= Time.deltaTime;
            if (tiempoSiguienteDa�o <= 0)
            {
                collision.GetComponent<CombateJugador>().TomarDa�o(da�o);
                tiempoSiguienteDa�o = tiempoEntreDa�o;
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
