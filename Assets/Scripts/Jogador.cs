using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private CharacterController character; 
    private Animator animator;
    private Vector3 inputs;
    private float velocidade = 7.5f;
    public float goiabaSpeed = 2f;
    [SerializeField] private GameObject goiabaPrefab;
    [SerializeField] private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(0, Input.GetAxis("Vertical"), 0); 
        character.Move(inputs * Time.deltaTime * velocidade);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad0)){
            Shoot();
        }
    }

    private void Shoot(){
        GameObject goiaba = Instantiate(goiabaPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = goiaba.GetComponent<Rigidbody2D>();

        // Aplicar velocidade à goiaba na direção em que o Chico está olhando
        rb.velocity = transform.right * goiabaSpeed;

        // Ativa a animação do tiro
        animator.SetTrigger("tiro");

        // Destruir a goiaba após 3 segundos
        Destroy(goiaba, 3f);
    }
}
