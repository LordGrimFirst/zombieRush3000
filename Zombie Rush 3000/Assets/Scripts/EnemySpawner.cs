using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject entityPrefab; // Das Prefab der Entity, die gespawnt werden soll
    public int numberOfEntities = 10; // Anzahl der zu spawnenden Entities
    public float minRadius = 15f; // Mindestdistanz von der Mitte
    public float maxRadius = 25f; // Maximale Distanz (Radius des Kreises)

    void Start()
    {
        SpawnEntitiesInCircle();
    }

    void SpawnEntitiesInCircle()
    {
        for (int i = 0; i < numberOfEntities; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfEntities; // Berechnung des Winkels
            // Generiere einen zufälligen Radius zwischen minRadius und maxRadius
            float radius = Random.Range(minRadius, maxRadius);
            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius; // Berechnung der Position
            Instantiate(entityPrefab, spawnPosition, Quaternion.identity); // Entity spawnen
        }
    }
}
