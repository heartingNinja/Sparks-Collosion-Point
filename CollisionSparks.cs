using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSparks : MonoBehaviour
{
    public GameObject sparksTrigger;      // The GameObject to move to the impact point
    public ParticleSystem scrapeSparks;   // The ParticleSystem for sparks

    // Threshold for triggering sparks
    public float impactThreshold = 5f;

    private void Start()
    {
        sparksTrigger.SetActive(false);   // Initially deactivate the sparks trigger
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Calculate impact force
        float impactForce = collision.relativeVelocity.magnitude;

        // Check if impact force is above the threshold
        if (impactForce > impactThreshold)
        {
            // Get the contact point of the collision
            ContactPoint contact = collision.contacts[0];
            Vector3 impactPosition = contact.point;
            Quaternion impactRotation = Quaternion.LookRotation(contact.normal);

            // Move the sparks trigger to the impact position and align it
            sparksTrigger.transform.position = impactPosition;
            sparksTrigger.transform.rotation = impactRotation;

            // Activate the sparks trigger and start the particle effect
            sparksTrigger.SetActive(true);
            scrapeSparks.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Deactivate the sparks trigger and stop the particle effect when the collision ends
        sparksTrigger.SetActive(false);
        scrapeSparks.Stop();
    }
}
