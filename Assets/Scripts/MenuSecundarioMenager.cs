using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundarioMenager : MonoBehaviour
{
    [SerializeField] private string MenuPrincipal;
    [SerializeField] private string MenuFases;
    [SerializeField] private string Inventario;

    public void Voltar(){        
        SceneManager.LoadScene(0);
    }

    public void VoltarInventario(){
        SceneManager.LoadScene(1);
    }

    public void AvancaFases(){
        SceneManager.LoadScene(2);
    }
}
 