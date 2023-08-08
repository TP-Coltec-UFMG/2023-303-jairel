using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    private int maxLife = 60;
    private int currentLife;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("mexe", true);
        currentLife = maxLife; // Initialize current life
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            Destroy(other.gameObject);

            currentLife--;

            if (currentLife <= 0)
                Destroy(gameObject); // Destroy the mob
        }

        if (other.CompareTag("barrera"))
        {
            GameManager.instance.FinalizarJogo();
        }
    }
}
