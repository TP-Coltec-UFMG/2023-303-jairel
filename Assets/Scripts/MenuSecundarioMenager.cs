using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundarioMenager : MonoBehaviour
{
    [SerializeField] private string MenuPrincipal;

    public void Voltar(){        
        SceneManager.LoadScene(MenuPrincipal);
    }
}
