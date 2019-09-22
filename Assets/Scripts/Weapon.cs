using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform weaponPosition;
    private GameObject currentProjectile;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {
        if (currentProjectile == null)
        {
            currentProjectile = Instantiate(ProjectilePrefab, weaponPosition.position,Quaternion.Euler(new Vector3(90,0,0)));
            var rocket = currentProjectile.GetComponent<Rocket>();
            rocket.SetDirectionAndOrigin(gameObject.transform.forward,this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
