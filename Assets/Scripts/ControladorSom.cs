using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ControladorSom : MonoBehaviour
{
    public AudioMixer mixer;
    private bool isMutedFundoMusical = false;
    private bool isMutedEfeitosSonoros = false;
    private float previousMusicalVolume;
    private float previousEfeitosVolume;

    private void Start()
    {
        // Obtém os volumes iniciais ao iniciar o jogo
        mixer.GetFloat("Fundo", out previousMusicalVolume);
        mixer.GetFloat("EfeitosSonoros", out previousEfeitosVolume);
    }

    public void VolumeMusical(float value)
    {
        if (!isMutedFundoMusical)
        {
            mixer.SetFloat("Fundo", Mathf.Log10(value) * 20);
        }
    }

    public void VolumeEfeitosSonoros(float value)
    {
        if (!isMutedEfeitosSonoros)
        {
            mixer.SetFloat("EfeitosSonoros", Mathf.Log10(value) * 20);
        }
    }

    public void ToggleMuteFundoMusical()
    {
        isMutedFundoMusical = !isMutedFundoMusical;

        if (isMutedFundoMusical)
        {
            MuteFundoMusical();
        }
        else
        {
            UnmuteFundoMusical();
        }
    }

    public void ToggleMuteEfeitosSonoros()
    {
        isMutedFundoMusical = !isMutedFundoMusical;

        if (isMutedFundoMusical)
        {
            MuteEfeitosSonoros();
        }
        else
        {
            UnmuteEfeitosSonoros();
        }
    }

    private void MuteEfeitosSonoros()
    {
        mixer.SetFloat("EfeitosSonoros", -80);
    }

    private void MuteFundoMusical()
    {
        mixer.SetFloat("Fundo", -80);
    }

    private void UnmuteEfeitosSonoros()
    {
        mixer.SetFloat("EfeitosSonoros", previousEfeitosVolume);
    }

    private void UnmuteFundoMusical()
    {
        mixer.SetFloat("Fundo", previousMusicalVolume);
    }

}
