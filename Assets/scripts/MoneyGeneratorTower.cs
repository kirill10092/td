using UnityEngine;

public class MoneyGeneratorTower : MonoBehaviour
{
    public int goldPerTick = 10;       // Сколько денег даёт за один раз
    public float generateInterval = 5f; // Интервал в секундах между выдачей денег

    void Start()
    {
        // Запускаем повторяющийся вызов метода GenerateMoney каждые generateInterval секунд
        InvokeRepeating(nameof(GenerateMoney), generateInterval, generateInterval);
    }

    void GenerateMoney()
    {
        PlayerStats.Money += goldPerTick;
        Debug.Log($"Дано {goldPerTick} денег. Всего денег: {PlayerStats.Money}");
    }
}
