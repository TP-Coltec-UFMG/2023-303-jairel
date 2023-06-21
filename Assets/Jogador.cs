using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private CharacterController character; 
    private Animator animator;
    private Vector3 inputs;
    private float velocidade = 2f;

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
    }
}





