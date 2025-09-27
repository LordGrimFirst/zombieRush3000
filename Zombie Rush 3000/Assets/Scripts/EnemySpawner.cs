using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject entityPrefab; // Das Prefab der Entity, die gespawnt werden soll
    public int numberOfEntities = 10; // Anzahl der zu spawnenden Entities
    public float minRadius = 15f; // Mindestdistanz von der Mitte
    public float maxRadius = 25f; // Maximale Distanz (Radius des Kreises)
    public GameObject player; // Referenz auf das Spieler-GameObject
    private int i = 0;

    void Start()
    {
        SpawnEntitiesInCircle();
    }

    private void Update()
    {
        i++;
        if (i > 1000)
        {
            SpawnEntitiesInCircle();
            i = 0;
        }
    }

    void SpawnEntitiesInCircle()
    {
        if (player == null)
        {
            Debug.LogWarning("Player GameObject is not assigned!");
            return;
        }

        Vector3 playerPosition = player.transform.position; // Position des Spielers

        for (int i = 0; i < numberOfEntities; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfEntities; // Berechnung des Winkels
            // Generiere einen zufälligen Radius zwischen minRadius und maxRadius
            float radius = Random.Range(minRadius, maxRadius);
            Vector3 spawnPosition = playerPosition + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius; // Berechnung der Position
            Instantiate(entityPrefab, spawnPosition, Quaternion.identity); // Entity spawnen
        }
    }
}
