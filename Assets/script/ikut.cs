using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRandomTargetWithDynamicMovement : MonoBehaviour
{
    [Header("Target Settings")]
    public List<Transform> targets; // List of objects to choose from
    public float speed = 5f; // Speed of following
    public float minDistance = 1.5f; // Minimum distance to maintain from the target
    public float backAndForthDuration = 0.5f; // Duration of forward-backward movement

    [Header("Timer Settings")]
    public float followDuration = 3f; // Time (in seconds) to follow each target
    public float randomMoveDuration = 2f; // Time to move randomly before switching targets

    private Transform currentTarget;
    private float timer;
    private bool isRandomMoving = false; // Whether the object is currently moving randomly
    private bool isMovingBackward = false; // Whether the object is moving backward
    private Vector3 randomDirection;


    private void Player(Transform player)
    {
        targets.Add(player);
    }
    
    void Start()
    {
        EventsSystem.OnRegisterPlayerEvent = Player;
        // Initialize the timer and pick the first target
        timer = followDuration + randomMoveDuration; // Start with random movement
        StartRandomMovement();
    }

    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        if (isRandomMoving)
        {
            // Move in a random direction
            transform.position += randomDirection * speed * Time.deltaTime;

            // Stop random movement and start following target when randomMoveDuration ends
            if (timer <= followDuration)
            {
                isRandomMoving = false;
                PickRandomTarget();
            }
        }
        else
        {
            // Follow the current target if available
            if (currentTarget != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

                // Perform forward-backward movement if within minimum distance
                if (distanceToTarget > minDistance)
                {
                    MoveTowardsTarget();
                }
                else
                {
                    PerformBackAndForthMovement();
                }
            }

            // Switch to random movement and reset timer when followDuration ends
            if (timer <= 0f)
            {
                StartRandomMovement();
            }
        }
    }

    // Move towards the current target
    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            speed * Time.deltaTime
        );

        // Optional: Rotate to face the target
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Perform forward-backward movement near the target
    void PerformBackAndForthMovement()
    {
        if (!isMovingBackward)
        {
            // Move slightly forward
            transform.position = Vector3.MoveTowards(
                transform.position,
                currentTarget.position,
                (speed * 0.5f) * Time.deltaTime
            );
        }
        else
        {
            // Move slightly backward
            Vector3 backwardDirection = (transform.position - currentTarget.position).normalized;
            transform.position += backwardDirection * (speed * 0.5f) * Time.deltaTime;
        }

        // Switch between forward and backward movement
        StartCoroutine(SwitchBackAndForth());
    }

    // Switch between forward and backward movement with a delay
    IEnumerator SwitchBackAndForth()
    {
        yield return new WaitForSeconds(backAndForthDuration);
        isMovingBackward = !isMovingBackward;
    }

    // Start moving randomly
    void StartRandomMovement()
    {
        isRandomMoving = true;
        timer = randomMoveDuration;

        // Choose a random direction
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
    }

    // Pick a random target from the list
    void PickRandomTarget()
    {
        if (targets.Count > 0)
        {
            int randomIndex = Random.Range(0, targets.Count);
            currentTarget = targets[randomIndex];
            timer = followDuration; // Reset timer for following
        }
        else
        {
            Debug.LogError("No targets assigned to the list!");
        }
    }
}
