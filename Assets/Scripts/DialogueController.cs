using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    public Image dialogueImage; // A referência para a imagem do balão de diálogo
    public Sprite[] dialogueSprites; // Array de sprites das imagens do diálogo
    private int currentIndex = 0; // Índice da imagem atual
    public int cena;

    private void Start()
    {
        UpdateDialogueImage();
    }

    public void NextImage()
    {
        currentIndex++;
        if (currentIndex < dialogueSprites.Length)
        {
            UpdateDialogueImage();
        }
        else
        {
           SceneManager.LoadScene(cena);
        }
    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           NextImage(); 
        }
    }

    private void UpdateDialogueImage()
    {
        dialogueImage.sprite = dialogueSprites[currentIndex];
    }
}
