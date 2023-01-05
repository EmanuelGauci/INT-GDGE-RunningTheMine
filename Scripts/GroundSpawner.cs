using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    //spawn the tile prefab
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    //responsible for actually spawning the tile
    public void SpawnTile(){
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    //responsible for how many times the tile is spawned
    public void Start(){
        for (int i = 0; i < 25; i++)
        {
            SpawnTile();
        }
    }
}
