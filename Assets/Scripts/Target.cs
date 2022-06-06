
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float TotalHealth = 50f;
    private ParticleSystem particleSystem;
    private MeshRenderer meshRenderer;

    [SerializeField]
    private string booletColiderName;

    [SerializeField]
    private string groundColiderName;

    [SerializeField]
    private float minCollideSpeed=20f;

    [SerializeField]
    private float minCollideGroundSpeed = 0f;

    [SerializeField]
    private float targetDestroyDuration = 5f;

    [SerializeField]
    private float groundReference = -10f;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        meshRenderer = GetComponent<MeshRenderer>();
        particleSystem.Stop();
    }
    private void Update()
    {
        if (gameObject.transform.position.y < groundReference && gameObject.transform.localPosition.y < groundReference)
        {
            TakeDamage(TotalHealth);
        }
    }
    public void TakeDamage(float amount)
    {
        TotalHealth -= amount;
        if (TotalHealth <=0f)
        {
            TargetDestroy();
        }
    }

    private void TargetDestroy()
    {
        if (meshRenderer.enabled)
        {
            GlobalScoreSystem.NumberBlocksLeft -= 1;
            GlobalScoreSystem.PlayerScore += 1;
        }
        meshRenderer.enabled=false;
        particleSystem.Play();
        StartCoroutine(DestroyTargetGameObject(targetDestroyDuration));
    }

    private IEnumerator DestroyTargetGameObject(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(meshRenderer.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains(booletColiderName))
        {
            if (collision.relativeVelocity.magnitude > minCollideSpeed)
            {
                TakeDamage(TotalHealth);
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
                TakeDamage(TotalHealth);
            }
        }
    }
}
