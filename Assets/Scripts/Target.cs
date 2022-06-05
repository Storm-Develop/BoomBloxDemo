
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 50f;
    private ParticleSystem particleSystem;
    private MeshRenderer meshRenderer;
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
}
