using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private float projectileForce;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce, ForceMode.Force);
    }
}
