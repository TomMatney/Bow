using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] 
    private float projectileForce;

    public void Setforce(float force)
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * projectileForce * force, ForceMode.Force);
    }

}
