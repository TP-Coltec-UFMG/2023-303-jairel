using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTerciarioMenager : MonoBehaviour
{

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;

    public Scrollbar scrollbar;

    private void Start()
    {
        scrollbar.value = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            VoltarInventario();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FaseMula();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FaseBotoCorDeRosa();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FaseBumbaMeuBoi();
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

    public void FaseBotoCorDeRosa()
    {
        SceneManager.LoadScene("BotoCorDeRosa");
    }

public void FaseBumbaMeuBoi()
    {
        SceneManager.LoadScene("BumbaMeuBoi");
    }


}