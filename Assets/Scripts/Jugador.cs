using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private Animator animator;
    public float movementSpeed = 1f;
    public float fuerzaSalto = 1f;
    private Rigidbody2D rigidbody2D;
    float horizontalMovement;
    private float Xinicial, yInicial;
    

    
    // Start is called before the first frame update
    void Start()
    {
        Xinicial = transform.localScale.x;
        yInicial = transform.localScale.y;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        /*Movimiento de personaje*/
        horizontalMovement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalMovement, 0, 0) * Time.deltaTime * movementSpeed;

        /*Animaciones de correr y saltar*/
        animator.SetBool("Corriendo", horizontalMovement != 0.0f);

        if (horizontalMovement < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontalMovement > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

       

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2D.velocity.y) < 0.1)
        {
            animator.SetBool("Saltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }


       
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("Saltando", false);
        }
    }
    /*Reaparecer de caída*/
    public void Recolocar()
    {
        transform.position = new Vector3(Xinicial, yInicial, 0);
    }

}
