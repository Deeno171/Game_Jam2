using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    // Reference to the animator component
    private Animator animator;

    // Flag to check if enemies are present
    private bool enemiesDetected = true;

    void Start()
    {
        // Assuming the Animator is attached to the same GameObject
        animator = GetComponent<Animator>();

        // Check for enemies at the start
        CheckForEnemies();
    }

    void Update()
    {
        // Check for enemies continuously (you might want to optimize this based on your game logic)
        CheckForEnemies();

        // If no enemies are detected, trigger the animation
        if (!enemiesDetected)
        {
            // Trigger the animation by setting a parameter
            animator.SetTrigger(name:"Open");

            // You can add additional logic or events here if needed

            // Disable this script to prevent continuous checking
            enabled = false;
        }
    }

    void CheckForEnemies()
    {
        // Implement your logic to check for enemies
        // This can be through raycasting, colliders, or any other method specific to your game
        // For the sake of example, let's assume you have a tag named "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Update the flag based on the presence of enemies
        enemiesDetected = enemies.Length > 0;
    }
}
