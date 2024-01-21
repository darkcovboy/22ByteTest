using UnityEngine;

namespace World
{
    public class GridDrawer : MonoBehaviour
    {
        public int gridSizeX = 10; // Количество клеток по горизонтали
        public int gridSizeY = 10; // Количество клеток по вертикали
        public float cellSize = 1f; // Размер каждой клетки

        void Start()
        {
            DrawGrid();
        }

        void DrawGrid()
        {
            LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

            // Регулируем параметры линии (цвет, ширина и т. д.)
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;

            // Рисуем горизонтальные линии
            for (int y = 0; y <= gridSizeY; y++)
            {
                float yPos = y * cellSize;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, new Vector3(0, yPos, 0));
                lineRenderer.SetPosition(1, new Vector3(gridSizeX * cellSize, yPos, 0));
            }

            // Рисуем вертикальные линии
            for (int x = 0; x <= gridSizeX; x++)
            {
                float xPos = x * cellSize;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, new Vector3(xPos, 0, 0));
                lineRenderer.SetPosition(1, new Vector3(xPos, gridSizeY * cellSize, 0));
            }
        }

    }
}