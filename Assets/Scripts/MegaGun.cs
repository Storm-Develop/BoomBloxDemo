using BoomBoxEnums;

using UnityEngine;

public class MegaGun : MonoBehaviour
{
    public float damage = 10f; //TODO make it adjustable
    public float range = 100f; //TODO make it adjustable

    [SerializeField]
    public float bulletFlightTime = 3f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseClicks.LeftClick))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        bool hitTarget = Physics.Raycast(ray, out hit, range);


        var bullet = Instantiate(bulletPrefab);

        Bullet bulletObj = bullet.GetComponent<Bullet>();
        bulletObj.MoveBullet(ray.origin,ray.direction, mainCamera.transform.eulerAngles.y);

        GlobalScoreSystem.BulletsUsed += 1;


        /*     RaycastHit hit;
             Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

             bool hitTarget = Physics.Raycast(ray, out hit, range);
             var bullet = Instantiate(bulletPrefab);

             bullet.transform.position = mainCamera.ScreenToViewportPoint(Input.mousePosition);

             var bulletRotation = bullet.transform.rotation.eulerAngles;
             bullet.transform.rotation = Quaternion.Euler(bulletRotation.x, customBulletRotation, bulletRotation.z);
             bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);


             if (hitTarget)
             {
                 Debug.Log("Hit "+ hit.transform.name);

                 var target = hit.transform.GetComponent<Target>();

                 if (target!=null)
                 {
                     target.TakeDamage(damage);
                 }
             }*/
    }

}
