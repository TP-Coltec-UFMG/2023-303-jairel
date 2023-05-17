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


    public void setFalse(){
        painelMenuInicial.SetActive(false);
        painelAcessibilidades.SetActive(false);
        painelOpcoes.SetActive(false);
        painelInfo.SetActive(false);
        painelHelp.SetActive(false);
    }

    public void Start(){      
        Menu();
    }
    public void Menu(){
        setFalse();
        painelMenuInicial.SetActive(true);
    }
    public void Jogar(){
        somAvancar.Play();
        SceneManager.LoadScene(nomeDoLevelDoJogo);
    }
    public void AbrirOpcoes(){
        somAvancar.Play();
        setFalse();
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes(){
        somVoltar.Play();
        setFalse();
        painelMenuInicial.SetActive(true);
    }
    public void AbrirAcessibilidades(){
        somAvancar.Play();
        setFalse();
        painelAcessibilidades.SetActive(true);
    }
    public void FecharAcessibilidades(){
        somVoltar.Play();
        setFalse();
        painelOpcoes.SetActive(true);
    }
    public void AbrirInfo(){
        somAvancar.Play();
        setFalse();
        painelInfo.SetActive(true);
    }
    public void FecharInfo(){
        somVoltar.Play();
        setFalse();
        painelMenuInicial.SetActive(true);
    }
    public void AbrirHelp(){
        somAvancar.Play();
        setFalse();
        painelHelp.SetActive(true);
    }
    public void FecharHelp(){
        somVoltar.Play();
        setFalse();
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
