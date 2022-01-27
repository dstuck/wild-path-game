using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSpeed = 1.0f;

    private bool _isFrozen = true;
    public bool IsFrozen { get => _isFrozen; set => _isFrozen = value; }

    Vector2 moveDirection = new Vector2(0.0f, 1.0f);
    Vector3 rotationUnit = new Vector3(0.0f, 0.0f, 1.0f);
    float horizontal;
    float vertical;

    Rigidbody2D rigidbody2d;
    //Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //transform = GetComponent<Transform>();
        horizontal = 0.0f;
        vertical = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsFrozen = false;
        }
    }

    void ModifyDirection(float degrees)
    {
        //Quaternion rotation = transform.rotation;
        //rotation.z = rotation.z + degrees;
        gameObject.transform.Rotate(rotationUnit * degrees);
        moveDirection = Quaternion.Euler(0, 0, degrees) * moveDirection;
    }

    void FixedUpdate()
    {
        ModifyDirection(-horizontal * turnSpeed);
        if (!IsFrozen)
        {
            Vector2 newPosition = rigidbody2d.position + moveDirection * speed * Time.deltaTime;

            rigidbody2d.MovePosition(newPosition);
        }
    }
}
