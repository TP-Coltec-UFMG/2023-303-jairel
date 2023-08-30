using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundarioMenager : MonoBehaviour
{

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;
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
        Invoke("CarregarCenaMenuPrincipal", somVoltar.clip.length);
    }

    private void CarregarCenaMenuPrincipal()
    {
        SceneManager.LoadScene("MenuBlueScene");
    }

    public void AvancaFases()
    {
        somAvancar.Play();
        SceneManager.LoadScene(3);
        //Invoke("CarregarCenaFases", somAvancar.clip.length);
    }

    private void CarregarCenaMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    private void CarregarCenaInventario()
    {
        SceneManager.LoadScene(2);
    }

    private void CarregarCenaFases()
    {
        SceneManager.LoadScene(3);
    }


    public void FaseMula()
    {
        SceneManager.LoadScene(1);
        Jogador.instance.SetControlsEnabled(true);
        Time.timeScale = 1;
    }

}
