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
        SceneManager.LoadScene(MenuPrincipal);
    }

    public void VoltarInventario(){
        SceneManager.LoadScene(Inventario);
    }

    public void AvancaFases(){
        SceneManager.LoadScene(MenuFases);
    }
    
    public void FaseMula(){
        SceneManager.LoadScene("MulaSemCabeca");
    }
}
 