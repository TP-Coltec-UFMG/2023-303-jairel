using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundarioMenager : MonoBehaviour
{

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;

    public void Voltar()
    {
        somVoltar.Play();
        Invoke("CarregarCenaMenuPrincipal", somVoltar.clip.length);
    }

    public void VoltarInventario()
    {
        somVoltar.Play();
        Invoke("CarregarCenaInventario", somVoltar.clip.length);
    }

    public void AvancaFases()
    {
        somAvancar.Play();
        Invoke("CarregarCenaFases", somAvancar.clip.length);
    }

    private void CarregarCenaMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void CarregarCenaInventario()
    {
        SceneManager.LoadScene("Inventario");
    }

    private void CarregarCenaFases()
    {
        SceneManager.LoadScene("MenuFases");
    }
    
    public void FaseMula(){
        SceneManager.LoadScene("MulaSemCabeca");
    }
}
