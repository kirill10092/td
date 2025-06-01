using UnityEngine;
using System.Collections.Generic;

public class freezeTower : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 3f;
    public float slowAmount = 0.5f; // 50% замедление

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    private List<Enemy> enemiesInRange = new List<Enemy>();

    void Start()
    {
        InvokeRepeating(nameof(UpdateTargets), 0f, 0.5f);
    }

    void UpdateTargets()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        enemiesInRange.Clear();

        foreach (GameObject enemyGO in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemyGO.transform.position);
            if (distance <= range)
            {
                Enemy enemy = enemyGO.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemiesInRange.Add(enemy);
                }
            }
        }

        ApplySlow();
    }

    void ApplySlow()
    {
        foreach (Enemy enemy in enemiesInRange)
        {
            enemy.ApplySlow(slowAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
