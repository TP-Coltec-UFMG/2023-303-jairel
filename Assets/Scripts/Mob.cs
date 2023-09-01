using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private Collider2D coll2d; // Adicionado para referência ao collider
    private SpriteRenderer spriteRenderer;
    public int vidaMaxima;
    private int vidaAtual;

    public Sprite spriteMorto;
    public bool isDead = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        coll2d = GetComponent<Collider2D>(); // Referência ao collider
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.SetBool("mexe", true);
        vidaAtual = vidaMaxima;
    }

    private void Update()
    {
        if (isDead)
        {
            rb2d.velocity = Vector2.zero; // Congela o movimento
            coll2d.enabled = false; // Desativa o collider
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            vidaAtual--;
            Destroy(other.gameObject);

            if (vidaAtual <= 0)
                Morrer();
        }

        if (other.CompareTag("barrera"))
            GameManager.instance.FinalizarJogo();
    }

    private void Morrer()
    {
        if (!isDead)
        {
            isDead = true;

            animator.enabled = false;

            transform.localScale = new Vector3(0.25f, 0.25f, 0);
            spriteRenderer.sprite = spriteMorto;

            animator.SetBool("mexe", false);

            coll2d.enabled = false; // Desativa o collider

            GameManager.instance.mobsEliminated++; // Corrigido para incrementar a variável

            StartCoroutine(DestruirAposTempo(0.5f)); // Chama a corrotina para destruir o objeto após 0.5 segundos
        }
    }

    private IEnumerator DestruirAposTempo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        Destroy(gameObject);
    }
}