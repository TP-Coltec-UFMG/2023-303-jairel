using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Image dialogueImage; // A referência para a imagem do balão de diálogo
    public Sprite[] dialogueSprites; // Array de sprites das imagens do diálogo
    private int currentIndex = 0; // Índice da imagem atual

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
            // Diálogo concluído, você pode fazer algo aqui
        }
    }

    private void UpdateDialogueImage()
    {
        dialogueImage.sprite = dialogueSprites[currentIndex];
    }
}
