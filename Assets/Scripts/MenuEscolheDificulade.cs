using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEscolheDificulade : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuEscolheFase;
    [SerializeField] public GameObject MenuManager;
    [SerializeField] private GameManager boss;
    [SerializeField] private GameManager Mob;

    private CanvasGroup[] canvasGroups;
    GameObject[] objetosNaCena;

    private void Start()
    {
        objetosNaCena = GameObject.FindObjectsOfType<GameObject>();
        Menu();
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ClicaBotaoFacil();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ClicaBotaoMedio();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ClicaBotaoDificil();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            VoltaMenuFases();
        }
    }

    public void setFalse()
    {
        // Obtém todos os GameObjects ativos na cena atual

        // Itera por todos os GameObjects
        foreach (GameObject objeto in objetosNaCena)
        {
            // Verifique se o objeto não é a câmera principal e não possui a tag "CenaJogo"
            if (objeto.CompareTag("CenaJogo") || objeto.CompareTag("barrera") || objeto.CompareTag("parede"))
            {
                // Desative o objeto
                objeto.SetActive(false);
            }
        }
    }

    public void Menu()
    {
        setFalse();
        painelMenuEscolheFase.SetActive(true);
        MenuManager.SetActive(true);
    }

    private void Awake()
    {
        // Encontre todos os Canvas Groups em objetos filhos
        canvasGroups = GetComponentsInChildren<CanvasGroup>(true);
    }

    public void AtivaOuDesativaCena()
    {

        // Itera por todos os GameObjects
        foreach (GameObject objeto in objetosNaCena)
        {
            if (objeto.CompareTag("CenaJogo")|| objeto.CompareTag("barrera") || objeto.CompareTag("parede") || objeto.CompareTag("Event System"))
            {
                // Ative o objeto
                objeto.SetActive(true);
            }
            // Verifique se o objeto não é a Main Camera ou o MenuManager
            else if(objeto != Camera.main.gameObject && objeto != MenuManager)
            {
                // Desative o objeto
                objeto.SetActive(false);
            }
        }
    }

    public void ClicaBotaoFacil()
    {
        AtivaOuDesativaCena();
        if (boss != null)
        {
            boss.vidaBoss = 50 ;
        }

        if(Mob != null){
            
            Mob.velocidadeMob = 5;
        }

    }
    public void ClicaBotaoMedio()
    {
        AtivaOuDesativaCena();
        if (boss != null)
        {
            boss.vidaBoss = 70 ;
        }
        if(Mob != null){
            
            Mob.velocidadeMob = 8;
        }
    }
    public void ClicaBotaoDificil()
    {
        AtivaOuDesativaCena();
        if (boss != null)
        {
            boss.vidaBoss = 90 ;
        }
        if(Mob != null){
            
            Mob.velocidadeMob = 13;
        }
    }
    public void VoltaMenuFases(){
        SceneManager.LoadScene("MenuFases");
    }
}