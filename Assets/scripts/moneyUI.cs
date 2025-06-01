using UnityEngine;
using UnityEngine.UI;

public class moneyUI : MonoBehaviour
{
    
    public Text moneyText;
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();

    }
}
