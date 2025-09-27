using UnityEngine;

public class OrbitalStrike : MonoBehaviour
{
    public GameObject orbitalStikePrefab; // Das Prefab der Entity, die gespawnt werden soll
    public int numberOfEntities = 10; // Anzahl der zu spawnenden Entities
    public float minRadius = 3f; // Mindestdistanz von der Mitte
    public float maxRadius =6; // Maximale Distanz (Radius des Kreises)

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
            Instantiate(orbitalStikePrefab, spawnPosition, Quaternion.identity); // Entity spawnen
        }
    }
}
