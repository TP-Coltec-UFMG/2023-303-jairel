using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
	private Animator animator;
	
	void Awake(){
		animator = GetComponent<Animator>();
		animator.SetBool("mexe", true);		
	}


    // Método para tratar a colisão com o tiro
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            Destroy(gameObject); // Destroi a cobra
            Destroy(other.gameObject); // Destroi o tiro
        }
        
        if(other.CompareTag("barrera"))
        	GameManager.instance.FinalizarJogo();
    }
}
