using BoomBoxEnums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairController : MonoBehaviour
{
    [SerializeField]
    Sprite MoveIcon;

    [SerializeField]
    Sprite ShootIcon;

    private Image crossHairImage;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Input.mousePosition;
        crossHairImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Input.mousePosition;

        if (Input.GetMouseButton((int)MouseClicks.RightClick) || Input.GetMouseButton((int)MouseClicks.MiddleClick))
        {
            crossHairImage.sprite = MoveIcon;
        }
        else
        {
            crossHairImage.sprite = ShootIcon;
        }
    }
}
