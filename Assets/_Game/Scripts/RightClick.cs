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

    public StarterAssets.ThirdPersonController player;

    public float forcehold = 0f;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            player.SprintSpeed = 1;
            player.MoveSpeed = 1;
            zoom.Priority = 11;
            BowMode();
            Debug.Log("zoom");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            player.SprintSpeed = 5.335f;
            player.MoveSpeed = 2;
            zoom.Priority = 9;
            forcehold = 0f;
        }

    }
    private void BowMode()
    {
        if (Input.GetMouseButton(0))
        {
            forcehold += Time.deltaTime * 5f;
            Debug.Log(forcehold);
        }

        if (Input.GetMouseButtonUp(0))
        {
            FireProjectile();
            forcehold = 0f;
            Debug.Log("arrowrelease");

        }
    }

   
    private void FireProjectile()
    {
        GameObject arrow = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        arrow.GetComponent<Projectile>().Setforce(forcehold);
        Debug.Log("shot");
        //instanite object
        //bring object back
        //give more power as project is hold down
    }
   
}

