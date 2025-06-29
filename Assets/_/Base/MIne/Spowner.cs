using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] waypointGroups; // Each group = 1 enemy's waypoints
    public Transform player;

    void Start()
    {
        for (int i = 0; i < waypointGroups.Length; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, waypointGroups[i].transform.position, Quaternion.identity);

            Enemy_base enemyScript = enemy.GetComponent<Enemy_base>();
            enemyScript.player = player;

            enemyScript.waypoints = waypointGroups[i].GetComponentsInChildren<Transform>()
                .Where(t => t != waypointGroups[i].transform) // skip parent
                .ToArray();
        }
    }
}