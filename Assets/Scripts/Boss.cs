using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    public int maxLife;
    private int currentLife;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("mexe", true);
        currentLife = maxLife;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            Destroy(other.gameObject);
            currentLife--;

            if (currentLife <= 0){
                Destroy(gameObject);
                GameManager.instance.showWin();
            }
        }

        if (other.CompareTag("barrera"))
            GameManager.instance.FinalizarJogo();
    }
}
