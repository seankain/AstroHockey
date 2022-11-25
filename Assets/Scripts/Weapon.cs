using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource FireSound;
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
            currentProjectile = Instantiate(ProjectilePrefab, weaponPosition.position,Quaternion.identity);
            var rocket = currentProjectile.GetComponent<Rocket>();
            rocket.SetDirectionAndOrigin(gameObject.transform.forward,this.gameObject);
            FireSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
