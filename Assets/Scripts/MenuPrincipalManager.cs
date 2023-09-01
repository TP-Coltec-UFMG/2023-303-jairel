using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    public DialogueController dialogueController;
    private int previousMenu = 0;

    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelAcessibilidades;
    [SerializeField] private GameObject painelInfo;
    [SerializeField] private GameObject painelHelp;
    [SerializeField] private string Inventario;

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;

    private int currentMenu = 0; 
    private GameObject[] menus;

    public void setFalse(){
        painelMenuInicial.SetActive(false);
        painelAcessibilidades.SetActive(false);
        painelOpcoes.SetActive(false);
        painelInfo.SetActive(false);
        painelHelp.SetActive(false);
    }

    public void Start(){      
        menus = new GameObject[] { painelMenuInicial, painelOpcoes, painelAcessibilidades, painelInfo, painelHelp };
        SetActiveMenu(currentMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Menu();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentMenu == 0)
            {
                AbrirOpcoes();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentMenu == 0)
            {
                CarregarCenaInventario();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentMenu == 0)
            {
                SairJogo();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if ((currentMenu == 0) || (currentMenu == 1))
            {
                AbrirInfo();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if ((currentMenu == 0) || (currentMenu == 1))
            {
                AbrirHelp();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (currentMenu == 1)
            {
                AbrirAcessibilidades();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMenu == 1)
            {
                FecharOpcoes();
            }
            else if (currentMenu == 2)
            {
                FecharAcessibilidades();
            }
            else if (currentMenu == 3)
            {
                FecharInfo();
            }
            else if (currentMenu == 4)
            {
                FecharHelp();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMenu == 0)
            {
                CarregarCenaInventario();
            }
            if (currentMenu == 3)
            {
                dialogueController.NextImage();
            }
        }

    }

    private void SetActiveMenu(int index)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(i == index);
        }
    }

    public void Menu(){
        currentMenu = 0;
        previousMenu = 0;
        setFalse();
        painelMenuInicial.SetActive(true);
    }
    
    public void AbrirInventario()
    {
        currentMenu = 2;
        somAvancar.Play();
        Invoke("CarregarCenaInventario", somAvancar.clip.length);
    }

    private void CarregarCenaInventario()
    {
        SceneManager.LoadScene("Inventario");
    }

    public void AbrirOpcoes(){
        currentMenu = 1;
        previousMenu = 1;
        somAvancar.Play();
        setFalse();
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes(){
        currentMenu = 0;
        previousMenu = 0;
        somVoltar.Play();
        setFalse();
        painelMenuInicial.SetActive(true);
    }
    public void AbrirAcessibilidades(){
        currentMenu = 2;
        somAvancar.Play();
        setFalse();
        painelAcessibilidades.SetActive(true);
    }
    public void FecharAcessibilidades(){
        currentMenu = 1;
        somVoltar.Play();
        setFalse();
        painelOpcoes.SetActive(true);

    }
    public void AbrirInfo(){
        currentMenu = 3;
        somAvancar.Play();
        setFalse();
        painelInfo.SetActive(true);
    }
    public void FecharInfo(){
       if (previousMenu == 0)
        {
            currentMenu = 0;
            somVoltar.Play();
            setFalse();
            painelMenuInicial.SetActive(true);
        }
        else if (previousMenu == 1)
        {
            AbrirOpcoes();
        }
    }
    public void AbrirHelp(){
        currentMenu = 4;
        somAvancar.Play();
        setFalse();
        painelHelp.SetActive(true);
    }
    public void FecharHelp(){
        if (previousMenu == 0)
        {
            currentMenu = 0;
            somVoltar.Play();
            setFalse();
            painelMenuInicial.SetActive(true);
        }
        else if (previousMenu == 1)
        {
            AbrirOpcoes();
        }
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