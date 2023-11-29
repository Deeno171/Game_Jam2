 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1,10)]
    [SerializeField] private float speed = 10f;

    [Range(1,10)]
    [SerializeField] private float lifeTime = .5f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }
 
    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        
    }
}
