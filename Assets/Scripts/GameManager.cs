using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject mobPrefab;
    public GameObject tiroPrefab;
    public int numeroMobs = 40;
    public float velocidadeMob = 2f;
    public float intervaloEntreSpawns = 1f;
    private int mobsSpawned = 0;
    private int bossSpawned = 0;
    public int mobsEliminated = 0;

    public static GameManager instance;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject DialogueManager;
    private int currentDialogueIndex = 0;
    private bool showingDialogues = false;

    private float countdownTimer = 3f; // Tempo de contagem regressiva
    private bool countingDown = true;

    private bool isPause = false;

    void Start()
    {
        instance = this;
    }

    public void abreMenu(){
        Time.timeScale = 0;
        this.Menu.SetActive(true);
    }
    public void fechaMenu(){
        Time.timeScale = 1;
        this.Menu.SetActive(false);
        isPause = false;
    }

    private void Update()
    {

        if (isPause) abreMenu();
        else if (!isPause) fechaMenu();

        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

        if (countingDown)
        {
            countdownTimer -= Time.deltaTime;
            if (countdownTimer <= 0f)
                StartSpawning();
        }
        
        else
        {
            if (mobsEliminated >= numeroMobs && bossSpawned == 0)
            {
                bossSpawned = 1; // Para garantir que o chefe seja spawnado apenas uma vez
                Invoke("SpawnBoss", 4f); // Espere 4 segundos após eliminar todos os inimigos para spawnar o chefe
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

    private void SpawnBoss()
    {
        float randomY = Random.Range(-4f, 4f); // Posição Y aleatória
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f); // Posição de spawn à direita da tela
        GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
        boss.GetComponent<Rigidbody2D>().velocity = Vector2.left * 1; // Movimento da direita para a esquerda
    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;
        this.GameOver.SetActive(true);

        Jogador jogadorScript = FindObjectOfType<Jogador>();
        if (jogadorScript != null)
        {
            jogadorScript.SetControlsEnabled(false); // Desabilita os controles do jogador
        }
    }

    public void showWin()
    {
        Time.timeScale = 0;
        this.DialogueManager.SetActive(true);

        Jogador jogadorScript = FindObjectOfType<Jogador>();
        if (jogadorScript != null)
        {
            jogadorScript.SetControlsEnabled(false); // Desabilita os controles do jogador
        }
    }

    public void BackMenu(){
        MenuSecundarioMenager.instance.CarregarCenaFases();
    }
}
