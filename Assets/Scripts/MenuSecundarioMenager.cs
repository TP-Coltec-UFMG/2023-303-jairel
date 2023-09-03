using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundarioMenager : MonoBehaviour
{

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;

    public static MenuSecundarioMenager instance;

    void Start(){
        instance = this;
    }

    private void Update()
{
    // Escutar as teclas de seta
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        VoltarMenuPrincipal();
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        AvancaFases();
    }
}
    public void VoltarMenuPrincipal()
    {
        somVoltar.Play();
        SceneManager.LoadScene(0);
        //Invoke("CarregarCenaMenuPrincipal", somVoltar.clip.length);
    }

    private void CarregarCenaMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void AvancaFases()
    {
        somAvancar.Play();
        SceneManager.LoadScene("MenuFases");
        //Invoke("CarregarCenaFases", somAvancar.clip.length);
    }

    public void CarregarCenaFases()
    {
        SceneManager.LoadScene("MenuFases");
    }

    
}