using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    private void Awake()
    {
        // Проверка: если уже есть экземпляр — уничтожаем новый
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Не уничтожать при смене сцен
    }

    void Start()
    {
        // Можно настроить тут AudioSource при необходимости
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }
}
