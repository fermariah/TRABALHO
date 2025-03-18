using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personagem : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade, pulo = 5f;
    public Animator controllador;
    private bool nochao, andou;
    // Start is called before the first frame update
    void Start()
    {
        controllador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        Pular();

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            controllador.SetBool("andou", true);
        }

        else 
        {
            controllador.SetBool("andou", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && nochao)
        {
            controllador.SetTrigger("pulo");
        }
    }

    public void Andar()
    {
        rb.velocity = new Vector2(velocidade, y: rb.velocity.y);
    }

    public void Pular()
    {
        if (nochao && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, pulo); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            nochao = true; 
        }
    }
}