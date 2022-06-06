
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 50f;
    private ParticleSystem particleSystem;
    private MeshRenderer meshRenderer;

    [SerializeField]
    private string booletColiderName;

    [SerializeField]
    private string groundColiderName;

    [SerializeField]
    private float minCollideSpeed=20f;

    [SerializeField]
    private float minCollideGroundSpeed = 5f;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        meshRenderer = GetComponent<MeshRenderer>();
        particleSystem.Stop();
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <=0f)
        {
            TargetDestroy();
        }
    }

    private void TargetDestroy()
    {
        meshRenderer.enabled=false;
        particleSystem.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains(booletColiderName))
        {
            if (collision.relativeVelocity.magnitude > minCollideSpeed)
            {
                TakeDamage(50f);
            }
            else
            {
                TakeDamage(10f);
            }
        }
        else if (collision.collider.name.Contains(groundColiderName))
        {
            if (collision.relativeVelocity.magnitude > minCollideGroundSpeed)
            {
                TakeDamage(50f);
            }
        }
       //     audioSource.Play(); //TODO Plat audio
    }
}
