using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Debug.Log("shot");
    }
}

public class AimController : MonoBehaviour
{

}