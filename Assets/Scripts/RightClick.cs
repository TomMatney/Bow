using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RightClick : MonoBehaviour
{
    public CinemachineVirtualCameraBase vcam;
    public CinemachineVirtualCameraBase zoom;

    public GameObject projectile;
    public Transform projectileSpawnPoint;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            
            zoom.Priority = 11;
            BowMode();
            Debug.Log("zoom");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            zoom.Priority = 9;
        }

    }

    private void FireProjectile()
    {
        Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Debug.Log("shot");
    }
    private void BowMode()
    {
        if (Input.GetMouseButtonDown(0))
        {

            FireProjectile();
            Debug.Log("bowmod");
        }
    }
}

