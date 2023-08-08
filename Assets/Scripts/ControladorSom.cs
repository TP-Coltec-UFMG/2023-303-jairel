using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ControladorSom : MonoBehaviour
{
    public AudioMixer mixer;

    public void VolumeMusical(float value){
        mixer.SetFloat("Fundo", Mathf.Log10(value) * 20);
    }

    public void VolumeEfeitosSonoros(float value){
        mixer.SetFloat("EfeitosSonoros", Mathf.Log10(value) * 20);
    }
}
