using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    private void Start(){
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCrystal();
        SpawnGold();
    }
    
    //destroy ground tiles after player passes them because of RAM
    private void OnTriggerExit(Collider other){
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    
    public GameObject obstaclePrefab;
    //spawn the obstacles by choosing between prefabs with set locations
    void SpawnObstacle(){
        //<<TODO>>
        //fix transform child out of bounds error
        //<<TODO>>
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform ;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject crystalPrefab;
    //spawn crystal
    void SpawnCrystal(){
        //pick amount of crystals to spawn in one spawn cycle
        int crystalsToSpawn = 2;
        //spawn cycle
        for (int i = 0; i < crystalsToSpawn; i++)
        {
            //spawn crystals from prefab and saves crystal spawned in variable called temp
            GameObject temp = Instantiate(crystalPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public GameObject goldPrefab;
    //spawn gold
    void SpawnGold(){
        //pick amount of gold to spawn in one spawn cycle
        double goldToSpawn = 0.1;
        //spawn cycle
        for (double i = 0; i < goldToSpawn; i++){
            //spawn gold from prefab and saves crystal spawned in variable called temp
            GameObject temp = Instantiate(goldPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }
    //get random point to spawn resources
    Vector3 GetRandomPointInCollider(Collider collider){
        //set  random x, y z point ranges 
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), 
                                    Random.Range(collider.bounds.min.y, collider.bounds.max.y), 
                                    Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point)){
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        //return point of current method run
        return point;
    }
}
