using BoomBoxEnums;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float defaultBulletSpeed = 10f;

    [SerializeField]
    private float bulletSpeed = 10f;

    [SerializeField]
    private float bulletSpeedMax = 100f;

    [SerializeField]
    private float bulletHighThreshold = 0.7f;

    [SerializeField]
    private float icrementBulletSpeed = 40f;

    [SerializeField]
    private Slider bulletStrengthIndicator;

    [SerializeField]
    private Image bulletfillImage;

    [SerializeField]
    private Color extremeColor;

    [SerializeField]
    private Color defaultColor;

    void Start()
    {
        UpdateBulletStrengthIndicator();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton((int)MouseClicks.LeftClick))
        {
            if (bulletSpeed < bulletSpeedMax)
            {
                bulletSpeed+= icrementBulletSpeed* Time.deltaTime;
                UpdateBulletStrengthIndicator();
            }

        }
        if (Input.GetMouseButtonUp((int)MouseClicks.LeftClick))
        {
                FireBullet();
                bulletSpeed = defaultBulletSpeed;
                UpdateBulletStrengthIndicator();
        }

    }

    private void UpdateBulletStrengthIndicator()
    {
        bulletStrengthIndicator.value = bulletSpeed / bulletSpeedMax;
        if (bulletStrengthIndicator.value > bulletHighThreshold)
        {
            bulletfillImage.color = extremeColor;
        }
        else
        {
            bulletfillImage.color = defaultColor;
        }
    }


    void FireBullet()
    {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            bool hitTarget = Physics.Raycast(ray, out hit, range);

            var bullet = Instantiate(bulletPrefab);

            Bullet bulletObj = bullet.GetComponent<Bullet>();
            bulletObj.MoveBullet(ray.origin, ray.direction, mainCamera.transform.eulerAngles.y, bulletSpeed);

            GlobalScoreSystem.BulletsUsed += 1;
    }
}
