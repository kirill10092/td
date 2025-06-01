using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int StartMoney = 500;

    public static int Lives;
    public static int startLives = 5;

    public static int Rounds = 1; 

    private void Start()
    {
        Money = StartMoney;
        Lives = startLives;
    }

    
}