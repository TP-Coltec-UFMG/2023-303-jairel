using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mobPrefab; // Prefab do mob
    public GameObject tiroPrefab; // Prefab do tiro
    public int numeroMobs = 40; // Número de mobs a serem criados
    public float velocidadeMob = 2f; // Velocidade dos mobs
    public float intervaloEntreSpawns = 1f; // Intervalo de tempo entre cada spawn
    private int mobsSpawned = 0; // Contador de mobs spawnados

    public static GameManager instance;
    [SerializeField] private GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
    	   instance = this;
        // Inicia o spawn dos mobs em sequências aleatórias
        InvokeRepeating("SpawnMob", 0f, intervaloEntreSpawns);
    }

    // Função para spawnar um mob
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
            // Cancela o InvokeRepeating após spawnar todos os mobs
            CancelInvoke("SpawnMob");
        }
    }
    
    public void FinalizarJogo(){
    		Time.timeScale = 0;
    		this.GameOver.SetActive(true);
    }
    
}
