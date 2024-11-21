using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;


    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 3;
    [SerializeField] private float enemiesPerSecond = 0.2f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.5f;



    [Header("Events")]
    public static UnityEvent onEnemyDestroy;


    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    public int gold = 150;
    public int health = 100;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI healthText;


    private void Awake()
    {
        main = this;
        onEnemyDestroy = new UnityEvent();
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        goldText.text = "Gold:" + gold.ToString();
        healthText.text = "Lives:" + health.ToString();
        if (health <= 0)
        {
            isSpawning = false;
        }
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private IEnumerator WaitForNextWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        currentWave++;
        StartWave();
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        StartCoroutine(WaitForNextWave());
    }

    public void DealDamage(int damage)
    {
        health -= damage;
    }
    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}
