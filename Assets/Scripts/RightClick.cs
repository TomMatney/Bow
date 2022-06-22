using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RightClick : MonoBehaviour
{
    public CinemachineVirtualCameraBase vcam;
    public CinemachineBrain vbrain;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            
            Debug.Log("zoom");
        }

    }
}
