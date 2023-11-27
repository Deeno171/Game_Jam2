using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1.0f)] // Corrected the range for fireRate
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime = 0f; // Added a variable to track the next allowed fire time
    private Rigidbody2D rb;
    private float mx;
    private float my;
    private Vector2 mp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mp.y - transform.position.y, mp.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle);
        rb.velocity = new Vector2(mx, my).normalized * speed;

        // Check if the current time is greater than the next allowed fire time
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1 / fireRate; // Update the next allowed fire time
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(rb.velocity);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
