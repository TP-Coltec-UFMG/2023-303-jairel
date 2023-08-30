using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
	private CharacterController character; 
	private Animator animator;
	private Vector3 inputs;
	private float velocidade = 7.5f;
	private bool mouseMove = false;
	public float goiabaSpeed;
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
	        mouseMove = false;
	        Shoot();
	    }
	    
	    if (Input.GetMouseButtonDown(0)){
	    	mouseMove = true;
	    	Shoot();
	    }	
	    
	    if (mouseMove)
	    	MoveWithMouse();
	}
	
	private void MoveWithMouse()
	{
	    // Obter a posição do mouse no mundo
	    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	
	    // Calcular a direção do movimento apenas no eixo das ordenadas (vertical)
	    Vector3 direction = new Vector3(0f, mousePosition.y - transform.position.y, 0f);
	
	    // Mover o jogador na direção do mouse
	    character.Move(direction.normalized * Time.deltaTime * velocidade);
	}
	
	private void Shoot(){
	    GameObject goiaba = Instantiate(goiabaPrefab, firePoint.position, Quaternion.identity);
	    Rigidbody2D rb = goiaba.GetComponent<Rigidbody2D>();
	
	    // Aplicar velocidade à goiaba na direção em que o Chico está olhando
	    rb.velocity = transform.right * goiabaSpeed;
	
	    // Ativa a animação do tiro
	    animator.SetTrigger("tiro");
	
	    // Destruir a goiaba após 3 segundos
	    Destroy(goiaba, 1.5f);
	}
	
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
	    // Verificar se a colisão é com a parede
	    if (hit.gameObject.CompareTag("parede"))
	    {
	        // Obter a direção do movimento do jogador
	        Vector3 moveDirection = inputs.normalized;
	
	        // Obter a normal da parede (direção para fora da parede)
	        Vector3 wallNormal = hit.normal;
	
	        // Calcular a projeção da direção do movimento na normal da parede
	        Vector3 moveDirectionProjection = Vector3.Project(moveDirection, wallNormal);
	
	        // Subtrair a projeção da direção do movimento para evitar que o jogador se mova na direção da parede
	        inputs -= moveDirectionProjection;
	    }
	}
	
}
