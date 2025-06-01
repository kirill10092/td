using UnityEngine;

public class MoneyGeneratorTower : MonoBehaviour
{
    public int goldPerTick = 10;       // ������� ����� ��� �� ���� ���
    public float generateInterval = 5f; // �������� � �������� ����� ������� �����

    void Start()
    {
        // ��������� ������������� ����� ������ GenerateMoney ������ generateInterval ������
        InvokeRepeating(nameof(GenerateMoney), generateInterval, generateInterval);
    }

    void GenerateMoney()
    {
        PlayerStats.Money += goldPerTick;
        Debug.Log($"���� {goldPerTick} �����. ����� �����: {PlayerStats.Money}");
    }
}
