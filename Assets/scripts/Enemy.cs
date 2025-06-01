using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 2.5f; // начальная скорость
    [HideInInspector]
    public float speed;

    public int value = 50;

    private Transform target;
    private int wavepointIndex;

    private float slowTimer = 0f;


    public int health = 100;

    void Start()
    {
        speed = startSpeed;
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        if (slowTimer > 0)
        {
            slowTimer -= Time.deltaTime;
        }
        else
        {
            speed = startSpeed;
        }

        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.03f)
        {
            GetNextWaypoint();
        }
    }


    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    public void ApplySlow(float slowAmount)
    {
        speed = startSpeed * (1f - slowAmount);
        slowTimer = 0.5f; // длительность замедления
    }

}
