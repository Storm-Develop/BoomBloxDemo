using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    private float bulletSpawnDuration = 3f;

    private Rigidbody bulletRigidBody;

    void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
    }

    public void MoveBullet(Vector3 initPostion, Vector3 force, float rotationAngle , float bulletSpeed)
    {

        Vector3 rotation = bulletRigidBody.transform.rotation.eulerAngles;

        bulletRigidBody.transform.rotation = Quaternion.Euler(rotation.x, rotationAngle, rotation.z);
        bulletRigidBody.position = initPostion;
        bulletRigidBody.AddForce(force * bulletSpeed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(DestroyBullet(bulletSpawnDuration));
    }

    private IEnumerator DestroyBullet( float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bulletRigidBody.gameObject);
    }
}
