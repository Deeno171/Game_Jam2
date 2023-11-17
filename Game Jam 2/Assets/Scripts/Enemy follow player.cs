using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollowplayer : MonoBehaviour
{
    public Transform target;
    public float speed = 3f ;
    public float rotate_speed = 0.003f ;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    void FixedUpdate()
    {

    }

    void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotate_speed);
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("player").transform;
    }


}


