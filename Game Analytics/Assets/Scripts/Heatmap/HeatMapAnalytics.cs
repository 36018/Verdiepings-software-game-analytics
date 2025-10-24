using UnityEngine;
using System.IO;
using System.Linq;

public class HeatMapAnalytics : MonoBehaviour
{
    public float updateInterval = 1f; // Time in seconds between updates
    public float gridSize = 1; // Size of each grid cell
    public Transform player; // Reference to the player transform

    private HeatMapData heatMapData;
    private float timer;
    private string saveFilePath;

    private void Start()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "heatmap.json"); //change "heatmap.json" to "heatmap.txt" if you want a .txt file
        LoadHeatMapData();
    }

    private void Update()
    {
        if ((timer += Time.deltaTime) >= updateInterval)
        {
            timer = 0f;
            var pos = player.position;
            var point = heatMapData.points.FirstOrDefault(p => 
            p.x == Mathf.Round(pos.x / gridSize) * gridSize && 
            p.y == Mathf.Round(pos.z / gridSize) * gridSize);

            if(point != null)
            {
                point.visits++;
            }
            else
            {
                heatMapData.points.Add(new HeatPoint(
                    Mathf.Round(pos.x / gridSize) * gridSize, 
                    Mathf.Round(pos.z / gridSize) * gridSize));
            }
            File.WriteAllText(saveFilePath, JsonUtility.ToJson(heatMapData));
        }
    }
    private HeatMapData LoadHeatMapData()
    {
        heatMapData = File.Exists(saveFilePath)
            ? JsonUtility.FromJson<HeatMapData>(File.ReadAllText(saveFilePath))
            : new HeatMapData();
        return heatMapData;
    }

    private void OnAplicationQuit() =>
        File.WriteAllText(saveFilePath, JsonUtility.ToJson(heatMapData));

    private void OnDrawGizmos()
    {
        if (heatMapData?.points == null) return;

        foreach (var point in heatMapData.points)
        {
            Gizmos.color = new Color(1f, 0f, 0f, Mathf.Min(point.visits / 10f, 1f));
            Gizmos.DrawCube(new Vector3(point.x, 0, point.y), Vector3.one * gridSize);
        }
    }
}
