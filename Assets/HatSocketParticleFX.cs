using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HatSocketParticleFX : MonoBehaviour
{
    [Header("Particle Setup")]
    public GameObject particlePrefab; // Using GameObject & public to guarantee visibility
    public Transform spawnPoint;

    public void PlayHatParticle(SelectEnterEventArgs args)
    {
        if (particlePrefab == null) return;

        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
        Quaternion spawnRotation = spawnPoint != null ? spawnPoint.rotation : transform.rotation;

        GameObject fxObj = Instantiate(particlePrefab, spawnPosition, spawnRotation);
        
        // Try getting particle system from the instantiated object
        ParticleSystem fx = fxObj.GetComponentInChildren<ParticleSystem>();
        if (fx != null)
        {
            fx.Play();
            float totalDuration = fx.main.duration + fx.main.startLifetime.constantMax;
            Destroy(fxObj, totalDuration);
        }
        else
        {
            Destroy(fxObj, 3f); // Fallback destroy if it's a simple prefab
        }
    }
}