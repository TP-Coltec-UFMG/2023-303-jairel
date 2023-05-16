using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDoJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelAcessibilidades;
    [SerializeField] private GameObject painelInfo;
    [SerializeField] private GameObject painelHelp;

    public void Start(){        
        Menu();
    }
    public void Menu(){
        painelMenuInicial.SetActive(true);
        painelAcessibilidades.SetActive(false);
        painelOpcoes.SetActive(false);
        painelInfo.SetActive(false);
        painelHelp.SetActive(false);
    }
    public void Jogar(){
        SceneManager.LoadScene(nomeDoLevelDoJogo);
    }
    public void AbrirOpcoes(){
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes(){
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void AbrirAcessibilidades(){
        painelOpcoes.SetActive(false);
        painelAcessibilidades.SetActive(true);
    }
    public void FecharAcessibilidades(){
        painelAcessibilidades.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void AbrirInfo(){
        painelInfo.SetActive(true);
        painelMenuInicial.SetActive(false);
    }
    public void FecharInfo(){
        painelInfo.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void AbrirHelp(){
        painelHelp.SetActive(true);
        painelMenuInicial.SetActive(false);
    }
    public void FecharHelp(){
        painelHelp.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif
    }
}
