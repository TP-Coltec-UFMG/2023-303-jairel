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

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;


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
        somAvancar.Play();
        SceneManager.LoadScene(nomeDoLevelDoJogo);
    }
    public void AbrirOpcoes(){
        somAvancar.Play();
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes(){
        somVoltar.Play();
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }
    public void AbrirAcessibilidades(){
        somAvancar.Play();
        painelOpcoes.SetActive(false);
        painelAcessibilidades.SetActive(true);
    }
    public void FecharAcessibilidades(){
        somVoltar.Play();
        painelAcessibilidades.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void AbrirInfo(){
        somAvancar.Play();
        painelInfo.SetActive(true);
        painelMenuInicial.SetActive(false);
    }
    public void FecharInfo(){
        somVoltar.Play();
        painelInfo.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void AbrirHelp(){
        somAvancar.Play();
        painelHelp.SetActive(true);
        painelMenuInicial.SetActive(false);
    }
    public void FecharHelp(){
        somVoltar.Play();
        painelHelp.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo(){
        somVoltar.Play();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif
    }
}
