using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RegionConstraint : MonoBehaviour
{
    [Header("Region Settings")]
    public Transform objectToRestrict; // The object that will be constrained within this region

    private Collider2D regionCollider;

    void Start()
    {
        // Ensure this object has a Collider2D component set to Trigger
        regionCollider = GetComponent<Collider2D>();

        if (!regionCollider.isTrigger)
        {
            Debug.LogWarning("The region's collider must be set as 'Is Trigger'. Enabling it automatically.");
            regionCollider.isTrigger = true;
        }

        if (objectToRestrict == null)
        {
            Debug.LogError("No object assigned to restrict! Please assign an object in the Inspector.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object leaving the region is the one we are constraining
        if (other.transform == objectToRestrict)
        {
            // Move the object back into the region
            RepositionInsideRegion(objectToRestrict);
        }
    }

    private void RepositionInsideRegion(Transform obj)
    {
        // Get the bounds of the region
        Bounds bounds = regionCollider.bounds;

        // Clamp the object's position to stay within the bounds
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(obj.position.x, bounds.min.x, bounds.max.x),
            Mathf.Clamp(obj.position.y, bounds.min.y, bounds.max.y),
            obj.position.z // Keep the Z-position as is (useful for 2D games)
        );

        // Apply the clamped position
        obj.position = clampedPosition;

        Debug.Log($"Object repositioned to stay within the region: {clampedPosition}");
    }
}
