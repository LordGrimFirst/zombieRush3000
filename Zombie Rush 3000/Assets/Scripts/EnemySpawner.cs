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
        if (i > 2000)
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

        Vector3 playerPosition = player.transform.position;

        for (int i = 0; i < numberOfEntities; i++)
        {
            // Pick a random angle in radians (0 to 2π)
            float angle = Random.Range(0f, Mathf.PI * 2f);

            // Pick a random radius between min and max
            float radius = Random.Range(minRadius, maxRadius);

            // Convert polar coordinates → cartesian
            Vector3 spawnPosition = playerPosition + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;

            // Spawn enemy
            Instantiate(entityPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
