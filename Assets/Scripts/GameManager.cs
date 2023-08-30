    using System.Collections;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public GameObject bossPrefab;
        public GameObject mobPrefab;
        public int numeroMobs = 40;
        public float velocidadeMob = 2f;
        public float intervaloEntreSpawns = 1f;
        private int mobsSpawned = 0;
        private int bossSpawned = 0;
        public int mobsEliminated = 0;

        public static GameManager instance;
        [SerializeField] private GameObject GameOver;

        [SerializeField] private GameObject dialogueSequence;
        private float countdownTimer = 3f; // Tempo de contagem regressiva
        private bool countingDown = true;

        private void Start()
        {
            instance = this;
            Invoke(nameof(StartSpawning), countdownTimer);
        }

        private void Update()
        {
            if (mobsEliminated >= numeroMobs && bossSpawned == 0)
            {
                bossSpawned = 1;
                Invoke(nameof(SpawnBoss), 4f);
            }
        }

        private void StartSpawning()
        {
            countingDown = false;
            InvokeRepeating(nameof(SpawnMob), 0f, intervaloEntreSpawns);
        }

        private void SpawnMob()
        {
            if (mobsSpawned < numeroMobs)
            {
                float randomY = Random.Range(-4f, 4f);
                Vector3 spawnPosition = new Vector3(10f, randomY, 0f);
                GameObject mob = Instantiate(mobPrefab, spawnPosition, Quaternion.identity);
                mob.GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidadeMob;

                mobsSpawned++;
            }
            else
            {
                CancelInvoke(nameof(SpawnMob));
            }
        }

        private void SpawnBoss()
        {
            float randomY = Random.Range(-4f, 4f);
            Vector3 spawnPosition = new Vector3(10f, randomY, 0f);
            GameObject boss = Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            boss.GetComponent<Rigidbody2D>().velocity = Vector2.left;
        }

        public void FinalizarJogo()
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }
