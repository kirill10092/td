using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RangeVisualizer : MonoBehaviour
{
    public float radius = 3f;
    public int segments = 50;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = false;
        DrawCircle();
    }

    void DrawCircle()
{
    line.positionCount = segments + 1;
    float angle = 0f;

    for (int i = 0; i <= segments; i++)
    {
        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

        line.SetPosition(i, new Vector3(x, y, 0));
        angle += 360f / segments;
    }

    line.loop = true;
    line.startWidth = 0.05f;
    line.endWidth = 0.05f;

    // Создаём материал, поддерживающий прозрачность
    Material transparentMaterial = new Material(Shader.Find("Sprites/Default"));
    transparentMaterial.renderQueue = 3000; // обеспечить правильный порядок отрисовки
    line.material = transparentMaterial;

    // Устанавливаем полупрозрачный цвет
    Color transparentCyan = new Color(0f, 1f, 1f, 0.2f); // Cyan с альфой 0.2
    line.startColor = transparentCyan;
    line.endColor = transparentCyan;
}
}
