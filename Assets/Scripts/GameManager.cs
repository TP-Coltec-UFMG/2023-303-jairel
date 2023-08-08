using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mobPrefab;
    public GameObject tiroPrefab;
    public int numeroMobs = 40;
    public float velocidadeMob = 2f;
    public float intervaloEntreSpawns = 1f;
    private int mobsSpawned = 0;
    public int mobsEliminated = 0;

    public static GameManager instance;
    [SerializeField] private GameObject GameOver;

    [SerializeField] private GameObject dialogueSequence;
    private int currentDialogueIndex = 0;
    private bool showingDialogues = false;

    private float countdownTimer = 3f; // Tempo de contagem regressiva
    private bool countingDown = true;

    void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if (countingDown)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer <= 0f)
                StartSpawning();
        }
        
        else
        {
            if (mobsEliminated >= numeroMobs && !showingDialogues)
            {
                showingDialogues = true;
                Time.timeScale = 0;
                //ShowNextDialogue();
            }
        }
    }

    private void StartSpawning()
    {
        countingDown = false;
        // Inicia o spawn dos mobs em sequências aleatórias
        InvokeRepeating("SpawnMob", 0f, intervaloEntreSpawns);
    }

    private void SpawnMob()
    {
        if (mobsSpawned < numeroMobs)
        {
            float randomY = Random.Range(-4f, 4f); // Posição Y aleatória
            Vector3 spawnPosition = new Vector3(10f, randomY, 0f); // Posição de spawn à direita da tela
            GameObject mob = Instantiate(mobPrefab, spawnPosition, Quaternion.identity);
            mob.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidadeMob; // Movimento da direita para a esquerda

            mobsSpawned++;
        }
        else
        {
            CancelInvoke("SpawnMob");
        }
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.GameOver.SetActive(true);
    }
}
