using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObject : MonoBehaviour
{

    public GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 orgin;
    private Vector3 direction;

    private float currentHitDistance;


    // print(HitName);
    //  HitName = hit.collider.name;

    private void Update()
    {
        orgin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if(Physics.SphereCast(orgin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
        }
        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(orgin, orgin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(orgin + direction * currentHitDistance, sphereRadius);
    }
    
        
    

}
