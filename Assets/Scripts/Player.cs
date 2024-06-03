using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject weapon;

    [SerializeField] private Transform shootTransform;

    [SerializeField] private float shootInterval = 0.1f;

    private float lasShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new(horizontalInput, 0f, 0f);
        // transform.position += moveSpeed * Time.deltaTime * moveTo;

        //  키보드 제어
        // Vector3 moveTo = new(moveSpeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= moveTo;
        // }
        // else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += moveTo;
        // }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Math.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lasShotTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lasShotTime = Time.time;
        }
    }
}
