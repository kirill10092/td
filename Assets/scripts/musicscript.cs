using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance;

    private void Awake()
    {
        // ��������: ���� ��� ���� ��������� � ���������� �����
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // �� ���������� ��� ����� ����
    }

    void Start()
    {
        // ����� ��������� ��� AudioSource ��� �������������
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }
}
