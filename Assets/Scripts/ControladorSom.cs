using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorSom : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource fundoMusical;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private GameObject button;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoMusical.enabled = estadoSom;

        if (estadoSom)
        {
            button.GetComponent<Image>().sprite = somLigadoSprite;
            //muteImage.sprite = somLigadoSprite;
        }
        else
        {
            button.GetComponent<Image>().sprite = somDesligadoSprite;
            //muteImage.sprite = somDesligadoSprite;
        }
    }

    public void VolumeMusical(float value){
        fundoMusical.volume = value;
    }
}
