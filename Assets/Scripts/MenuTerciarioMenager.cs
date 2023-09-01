using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTerciarioMenager : MonoBehaviour
{

    [SerializeField] private AudioSource somAvancar;
    [SerializeField] private AudioSource somVoltar;
    private int previousMenu = 1;
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
        previousMenu = 1;
        somVoltar.Play();
        Invoke("CarregarMenuInventario", somVoltar.clip.length);
    }

    private void CarregarMenuInventario()
    {
        SceneManager.LoadScene("Inventario");
    }

    public void FaseMula()
    {
        SceneManager.LoadScene("MulaSemCabeca");
    }


}