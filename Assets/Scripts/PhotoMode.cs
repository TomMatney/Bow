using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PhotoMode : MonoBehaviour
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
        if (Input.GetMouseButton(1)) //right click hold down zooms in
        {
            player.SprintSpeed = 1;
            player.MoveSpeed = 1;
            zoom.Priority = 11;
            PhotoModeOn();
            Debug.Log("zoom");
        }
        else if (Input.GetMouseButtonUp(1)) //right click release zooms out
        {
            player.SprintSpeed = 5.335f;
            player.MoveSpeed = 2;
            zoom.Priority = 9;
            forcehold = 0f;
        }

    }
    private void PhotoModeOn()
    {
        if (Input.GetMouseButtonDown(0)) //if zoom in you can press left to start gaining force
        { 
            Debug.Log("take a shot");
        }

        //if (Input.GetMouseButtonUp(0)) //on left click you release force
        //{
        //    FireProjectile();
        //    forcehold = 0f;
        //    Debug.Log("arrowrelease");

        //}
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

