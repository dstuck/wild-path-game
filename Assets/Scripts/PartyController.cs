using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSpeed = 1.0f;

    private bool _isFrozen = true;
    public bool IsFrozen { get => _isFrozen; set => _isFrozen = value; }

    Vector2 moveDirection = new Vector2(1.0f, 0.0f);
    float horizontal;
    float vertical;

    Rigidbody2D rigidbody2d;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
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
        Debug.Log("horizontal" + horizontal);
        Debug.Log("IsFrozen" + IsFrozen);
    }

    void ModifyDirection(float degrees)
    {
        moveDirection = Quaternion.Euler(0, 0, degrees) * moveDirection;
    }

    void FixedUpdate()
    {
        if (!IsFrozen)
        {
            ModifyDirection(-horizontal * turnSpeed);
            Vector2 newPosition = rigidbody2d.position + moveDirection * speed * Time.deltaTime;

            rigidbody2d.MovePosition(newPosition);
        }
    }
}
