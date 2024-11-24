using UnityEngine;

public class CollisionSparks : MonoBehaviour
{
    public GameObject sparksTrigger;      // The GameObject to move to the impact point
    private ParticleSystem scrapeSparks;   // The ParticleSystem for sparks
    public float speedThresholdMph = 10f;   // Speed threshold in mph

    public LayerMask collisionLayer;

    private Rigidbody rb;

    private void Start()
    {
        // Find the Rigidbody in the current GameObject or parent
        rb = GetComponentInParent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody not found in parent hierarchy for CollisionSparks script");
        }

        scrapeSparks = sparksTrigger.GetComponentInChildren<ParticleSystem>();
        sparksTrigger.SetActive(false);   // Initially deactivate the sparks trigger
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ensure we have a Rigidbody to work with
        if (rb == null) return;

        // Check if the collided object's layer matches the collision layer
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            // Calculate the speed in mph
            float speedMph = rb.velocity.magnitude * 2.237f; // Convert m/s to mph

            // Check if speed is above the threshold
            if (speedMph > speedThresholdMph)
            {
                // Get the contact point of the collision
                // We use the first in the array for only starting play once on collison
                Collider contact = collision.GetContact(0).thisCollider;
                Vector3 impactPosition = collision.GetContact(0).point;
                Quaternion impactRotation = Quaternion.LookRotation(collision.GetContact(0).normal);

                // Move the sparks trigger to the impact position and align it
                sparksTrigger.transform.position = impactPosition;
                sparksTrigger.transform.rotation = impactRotation;

                // Activate the sparks trigger and start the particle effect
                sparksTrigger.SetActive(true);
              
                scrapeSparks.Play();
            }
        }      
    }

    private void OnCollisionExit(Collision collision)
    {
        // Deactivate the sparks trigger and stop the particle effect when the collision ends
        sparksTrigger.SetActive(false);
        
        scrapeSparks.Stop();
    }
}
