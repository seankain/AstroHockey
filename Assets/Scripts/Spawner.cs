using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerType
{
    PlayerShip,
    EnemyShip
}

public class Spawner : MonoBehaviour
{
    public delegate void Spawned(int instanceId);
    public Spawned OnSpawned;

    public Team Team;
    public Vector3 SpawnRotation;
    public GameObject Prefab;
    public float SpawnLag = 2;
    public bool IsEnemySpawner = false;
    private GameObject CurrentInstance;
    private float elapsed = 0;
    private bool IsSpawning = false;
    private bool IsActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleActive(bool active)
    {
        IsActive = active;
    }

    public void Despawn()
    {
        if (CurrentInstance != null)
        {
            Destroy(CurrentInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive || CurrentInstance != null) { return; }
            IsSpawning = true;
            elapsed += Time.deltaTime;
            if(elapsed >= SpawnLag)
            {
                Spawn();
                elapsed = 0;
                IsSpawning = false;
            }
    }

    private void Spawn()
    {
       CurrentInstance = Instantiate(Prefab, this.transform.position,Quaternion.Euler(SpawnRotation));
        CurrentInstance.GetComponent<Ship>().SetTeam(Team);
        if (OnSpawned != null) { OnSpawned.Invoke(CurrentInstance.GetInstanceID()); }
    }
}
