using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTerciarioMenager : MonoBehaviour
{

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            VoltarInventario();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            FaseMula();
        }
    }

    public void VoltarInventario()
    {
        somVoltar.Play();
        SceneManager.LoadScene(2);
        //Invoke("CarregarMenuInventario", somVoltar.clip.length);
    }

    private void CarregarMenuInventario()
    {
        SceneManager.LoadScene(2);
    }

    public void FaseMula()
    {
        SceneManager.LoadScene(1);
    }
    
    public void FaseBoto()
    {
        SceneManager.LoadScene(4);
    }
    
    /*public void FaseBoi()
    {
        SceneManager.LoadScene(1);
    }*/


}