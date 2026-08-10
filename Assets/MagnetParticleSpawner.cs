using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagnetParticleSpawner : MonoBehaviour
{
    [Header("Particle Settings")]
    [SerializeField] private ParticleSystem particlePrefab; // Drag your Particle Prefab here
    [SerializeField] private Transform spawnPoint;         // Where particles pop out (e.g., Magnet surface)

    /// <summary>
    /// Attach this to the Socket Interactor's Select Entered Event
    /// </summary>
    public void PlayMagnetParticles(SelectEnterEventArgs args)
    {
        if (particlePrefab == null) return;

        // Determine spawn location (defaults to this object's position if spawnPoint isn't set)
        Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
        Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

        // Instantiate and play
        ParticleSystem particles = Instantiate(particlePrefab, position, rotation);
        particles.Play();

        // Destroy particle object after its duration finishes
        Destroy(particles.gameObject, particles.main.duration + particles.main.startLifetime.constantMax);
    }
}