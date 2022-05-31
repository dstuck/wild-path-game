using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float turnSpeed = 1.0f;

    public int goldCount = 0;
    private int winningGoldCount = 2;

    public bool IsFrozen { get; set; } = true;

    public JobBase[] availableJobs;
    private JobBase curJob;

    Vector3 startPos;


    Vector2 moveDirection = new Vector2(0.0f, 1.0f);
    Vector3 rotationUnit = new Vector3(0.0f, 0.0f, 1.0f);
    float horizontal;
    float vertical;

    Rigidbody2D rigidbody2d;
    //Transform transform;


    // Start is called before the first frame update
    void Start()
    {
        availableJobs = new JobBase[] { new RangerJob(), new KnightJob() };
        ChangeJob(0);

        rigidbody2d = GetComponent<Rigidbody2D>();
        horizontal = 0.0f;
        vertical = 0.0f;
        startPos = transform.position;
    }

    public void Reset()
    {
        IsFrozen = true;
        transform.position = startPos;
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeJob(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeJob(1);
        }

    }

    void ChangeJob(int newIndex)
    {
        Debug.Log("Changing job to: " + newIndex);
        if (curJob != availableJobs[newIndex])
        {
            Debug.Log("New job, setting sprite");

            curJob = availableJobs[newIndex];
            curJob.SetSprite(gameObject);
            speed = curJob.GetSpeed();
            turnSpeed = curJob.GetTurnSpeed();
        }
    }

    public void ModifyDirection(float degrees)
    {
        gameObject.transform.Rotate(rotationUnit * degrees);
        //moveDirection = Quaternion.Euler(0, 0, degrees) * moveDirection;
    }

    void FixedUpdate()
    {
        ModifyDirection(-horizontal * turnSpeed);
        if (!IsFrozen)
        {
            Vector2 newPosition = rigidbody2d.position + (Vector2) gameObject.transform.TransformDirection((Vector3) moveDirection) * speed * Time.deltaTime;
            
            rigidbody2d.MovePosition(newPosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnvironmentalObject envObj = collision.gameObject.GetComponent<EnvironmentalObject>();
        if (envObj != null)
        {
            envObj.OnPlayerCollision(this);
        }
        if (collision.gameObject.GetComponent<Gold>() != null)
        {
            goldCount += 1;
            if (goldCount >= winningGoldCount) {
                
                FindObjectOfType<GameManager>().EndGame();
            }
        }

    }
}
