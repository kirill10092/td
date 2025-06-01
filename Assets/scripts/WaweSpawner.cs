using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public EnemyWave[] waves;
    private int currentWaveIndex = 0;

    [Header("Spawn Settings")]
    public Transform spawnPoint;

    [Header("UI")]
    public Text waveCountDownText;

    private bool isSpawning = false;

    private float countdown = 0f;

    void Start()
    {
        if (waves.Length > 0)
        {
            countdown = waves[currentWaveIndex].timeBeforeWave;
        }
    }

    void Update()
    {
        if (isSpawning || currentWaveIndex >= waves.Length)
            return;

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            countdown = Mathf.Max(countdown, 0f);

            if (waveCountDownText != null)
                waveCountDownText.text = $"Next wave in: {countdown:0.00}s";
        }
        else
        {
            StartCoroutine(SpawnWave(waves[currentWaveIndex]));
        }
    }

    IEnumerator SpawnWave(EnemyWave wave)
    {
        isSpawning = true;
        PlayerStats.Rounds++;
        PlayerStats.Money += 50 + currentWaveIndex * 5;

        if (waveCountDownText != null)
            waveCountDownText.text = $"Wave {currentWaveIndex + 1} in progress";

        if (wave.enemies.Length != wave.counts.Length)
        {
            Debug.LogError("Wave configuration mismatch: enemies and counts arrays must be the same length.");
            yield break;
        }

        for (int i = 0; i < wave.enemies.Length; i++)
        {
            for (int j = 0; j < wave.counts[i]; j++)
            {
                Instantiate(wave.enemies[i], spawnPoint.position, spawnPoint.rotation);
                yield return new WaitForSeconds(wave.delay);
            }
        }

        currentWaveIndex++;
        isSpawning = false;

        if (currentWaveIndex < waves.Length)
        {
            countdown = waves[currentWaveIndex].timeBeforeWave;
        }
        else
        {
            if (waveCountDownText != null)
                waveCountDownText.text = "All waves complete!";
        }
    }
}

[System.Serializable]
public class EnemyWave
{
    public GameObject[] enemies;
    public int[] counts;
    public float delay = 0.5f;
    public float timeBeforeWave = 5f;
}
