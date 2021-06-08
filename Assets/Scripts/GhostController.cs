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
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {        
        //Sets rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Update timers
        timerX -= Time.deltaTime;
        timerY -= Time.deltaTime;

        //Adds new moves
        if(timerX <= 0)
        {
            if (timeRecordX.Count != 0)
            {
                timerX = timeRecordX.Dequeue();
                moveX = moveRecordX.Dequeue();
            }
            else if (timeRecordY.Count == 0)
                Destroy(gameObject);
            else
            {
                timerX = 100;
                moveX = 0;
            }
        }
        if (timerY <= 0)
        {
            if (timeRecordY.Count != 0)
            {
                timerY = timeRecordY.Dequeue();
                moveY = moveRecordY.Dequeue();
            }
            else if (timeRecordX.Count == 0)
                Destroy(gameObject);
            else
            {
                timerY = 100;
                moveY = 0;
            }
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
        timeRecordX = new Queue<float>(timeInputX);
        timeRecordY = new Queue<float>(timeInputY);
        moveRecordX = new Queue<int>(moveInputX);
        moveRecordY = new Queue<int>(moveInputY);
        moveSpeed = moveInputSpeed;

        print(timeRecordX.Count + " moves horizontally");
        print(timeRecordY.Count + " moves vertically");

        //Starts movement
        timerX = timeRecordX.Dequeue();
        moveX = moveRecordX.Dequeue();
        timerY = timeRecordY.Dequeue();
        moveY = moveRecordY.Dequeue();
    }
}

