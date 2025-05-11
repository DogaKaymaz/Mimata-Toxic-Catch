using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform cellParent;
    public int width = 6; // x
    public int height = 8; // y
    public float cellSize = 50f;
    public float spacing = 5f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        Clear(cellParent);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject cell = Instantiate(cellPrefab, cellParent);
                RectTransform rt = cell.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(cellSize, cellSize);
                rt.anchoredPosition = new Vector2(x * (cellSize + spacing), -y * (cellSize + spacing));
            }
        }
    }

    private void Clear(Transform targetTransform)
    {
        foreach (Transform child in targetTransform.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
