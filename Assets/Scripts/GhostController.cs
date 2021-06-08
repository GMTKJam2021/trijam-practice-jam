using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private Queue<float> timeRecordX;
    private Queue<int> moveRecordX;
    private Queue<float> timeRecordY;
    private Queue<int> moveRecordY;
    private float timerX;
    private float timerY;
    private int moveX;
    private int moveY;
    private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {        
        //Initializes all queues
        timeRecordX = new Queue<float>();
        timeRecordY = new Queue<float>();
        moveRecordX = new Queue<int>();
        moveRecordY = new Queue<int>();

        //Starts timers
        timerX = timerY = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Update timers
        timerX -= Time.deltaTime;
        timerY -= Time.deltaTime;

        //Adds new moves
        if(timerX <= 0)
        {
            timerX = timeRecordX.Dequeue();
            moveX = moveRecordX.Dequeue();
        }
        if (timerY <= 0)
        {
            timerY = timeRecordY.Dequeue();
            moveY = moveRecordY.Dequeue();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX, moveY) * moveSpeed;
    }

    /// <summary>
    /// Adds the records of the player movement for the ghost to use.
    /// </summary>
    /// <param name="timeInputX">The time associated to each player move horizontally.</param>
    /// <param name="timeInputY">The time associated to each player move vertically.</param>
    /// <param name="moveInputX">The direction associated to each player move horizontally.</param>
    /// <param name="moveInputY">The direction associated to each player move vertically.</param>
    /// <param name="moveInputSpeed">The speed the player was moving at.</param>
    public void AddRecord(Queue<float> timeInputX, Queue<float> timeInputY, Queue<int> moveInputX, Queue<int> moveInputY, float moveInputSpeed)
    {
        //Sets parameters
        timeRecordX = timeInputX;
        timeRecordY = timeInputY;
        moveRecordX = moveInputX;
        moveRecordY = moveInputY;
        moveSpeed = moveInputSpeed;

        //Starts movement
        timerX = timeRecordX.Dequeue();
        moveX = moveRecordX.Dequeue();
        timerY = timeRecordY.Dequeue();
        moveY = moveRecordY.Dequeue();
    }
}

