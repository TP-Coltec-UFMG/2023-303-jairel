using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundarioMenager : MonoBehaviour
{
    [SerializeField] private string MenuPrincipal;
    [SerializeField] private string MenuFases;
    [SerializeField] private string Inventario;

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
        SceneManager.LoadScene(0);
    }

    private void CarregarCenaInventario()
    {
        SceneManager.LoadScene(1);
    }

    private void CarregarCenaFases()
    {
        SceneManager.LoadScene(2);
    }
}