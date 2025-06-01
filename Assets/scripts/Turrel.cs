using UnityEngine;

public class Turrel : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 1f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public float turnSpeed = 200f;

    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestenemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestenemy = enemy;
            }
        }

        if (nearestenemy != null && shortestDistance <= range)
        {
            target = nearestenemy.transform;
        }
        else
        {
            target = null;
        }

    }


    void Update()
    {
        fireCountdown -= Time.deltaTime;

        if (target == null)
        {
            return;
        }

        Vector2 direction = target.position - transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = transform.eulerAngles.z;
        float angle = Mathf.LerpAngle(currentAngle, targetAngle, turnSpeed * Time.deltaTime / 360f);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}
