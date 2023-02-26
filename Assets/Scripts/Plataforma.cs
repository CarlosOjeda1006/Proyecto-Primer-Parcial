using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{

    [SerializeField] private Transform[] puntosMovi;
    [SerializeField] private float velocidadMovi;

    private int siguientePlat = 1;
    private bool ordenPlataf = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ordenPlataf && siguientePlat + 1 >= puntosMovi.Length)
        {
            ordenPlataf = false;
        }

        if (!ordenPlataf && siguientePlat <= 0)
        {
            ordenPlataf = true;
        }

        if (Vector2.Distance(transform.position, puntosMovi[siguientePlat].position) < 0.1f)
        {
            if (ordenPlataf)
            {
                siguientePlat += 1;
            }
            else
            {
                siguientePlat -= 1;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, puntosMovi[siguientePlat].position, velocidadMovi * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
