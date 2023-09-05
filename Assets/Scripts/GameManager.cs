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
    public int vidaBoss = 90;

    public static GameManager instance;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject DialogueManager;


    private float countdownTimer = 3f; // Tempo de contagem regressiva
    private bool countingDown = true;

    private bool isPause = false;
    private bool isGlobalPause = false; // Variável de pausa global

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1; // Garante que o tempo esteja normal ao carregar a cena
        isPause = false; // Garante que a pausa não esteja ativada ao carregar a cena
        isGlobalPause = false; // Garante que a pausa global não esteja ativada ao carregar a cena
    }
    
    public void abreMenu()
    {
        Time.timeScale = 0;
        this.Menu.SetActive(true);
        isPause = true;
    }

    public void fechaMenu()
    {
        Time.timeScale = 1;
        this.Menu.SetActive(false);
        isPause = false;
    }

    private void Update()
    {
        if (isGlobalPause)
        {
            // Lida com a pausa global
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            if (isPause)
            {
                abreMenu();
            }
            else
            {
                fechaMenu();
            }
        }

        if (isPause && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BackMenu();
        }

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
        isGlobalPause = true; // Ativa a pausa global
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
        isGlobalPause = true; // Ativa a pausa global
        Time.timeScale = 0;
        this.DialogueManager.SetActive(true);

        Jogador jogadorScript = FindObjectOfType<Jogador>();
        if (jogadorScript != null)
        {
            jogadorScript.SetControlsEnabled(false); // Desabilita os controles do jogador
        }
    }

    public void BackMenu()
    {
        isGlobalPause = false; // Desativa a pausa global
        SceneManager.LoadScene(3);
    }

    public void ResumeGame()
    {
        isGlobalPause = false; // Desativa a pausa global
        Time.timeScale = 1; // Volta ao tempo normal

        Jogador jogadorScript = FindObjectOfType<Jogador>();
        if (jogadorScript != null)
        {
            jogadorScript.SetControlsEnabled(true);
        }
}}
