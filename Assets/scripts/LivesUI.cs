using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;


 
    void Update()
    {
        livesText.text = "Lives: " + PlayerStats.Lives.ToString();
    }
}