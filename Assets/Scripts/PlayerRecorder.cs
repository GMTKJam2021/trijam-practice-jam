using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField] private GameObject ghost;
    private Vector3 initialPosition;
    private Queue<float> timeRecordX;
    private Queue<int> moveRecordX;
    private Queue<float> timeRecordY;
    private Queue<int> moveRecordY;
    private float timerX;
    private float timerY;
    private float lastX;
    private float lastY;

    private void Start()
    {
        //Initializes all queues
        timeRecordX = new Queue<float>();
        timeRecordY = new Queue<float>();
        moveRecordX = new Queue<int>();
        moveRecordY = new Queue<int>();

        //Starts timer
        timerX = timerY = 0;

        //Sets start position
        initialPosition = transform.position;
    }

    private void Update()
    {

        float newX = Input.GetAxisRaw("Horizontal"); // Check new horizontal input
        if (lastX > 0) // If player was moving right
        {
            if (newX <= 0) // and now is stopped or moving left
            {
                timeRecordX.Enqueue(timerX); // Record the new movement
                moveRecordX.Enqueue(1);
                timerX = 0;
            }
            else // otherwise keep the timer running
                timerX += Time.deltaTime;
        }
        else if (lastX < 0) // If player was moving left
        {
            if (newX >= 0) // and now is stopped or moving right
            {
                timeRecordX.Enqueue(timerX); // Record the new movement
                moveRecordX.Enqueue(-1);
                timerX = 0;
            }
            else // otherwise keep the timer running
                timerX += Time.deltaTime;
        }
        else // If player was still
        {
            if (newX != 0) // and now is moving left or right
            {
                timeRecordX.Enqueue(timerX); // Record the new movement
                moveRecordX.Enqueue(0);
                timerX = 0;
            }
            else // otherwise keep the timer running
                timerX += Time.deltaTime;
        }
        lastX = newX; // Record horizontal input

        float newY = Input.GetAxisRaw("Vertical"); // Check new vertical input

        if (lastY > 0) // If player was moving up
        {
            if (newY <= 0) // and now is stopped or moving down
            {
                timeRecordY.Enqueue(timerY); // Record the new movement
                moveRecordY.Enqueue(1);
                timerY = 0;
            }
            else // otherwise keep the timer running
                timerY += Time.deltaTime;
        }
        else if (lastY < 0) // If player was moving down
        {
            if (newY >= 0) // and now is stopped or moving up
            {
                timeRecordY.Enqueue(timerY); // Record the new movement
                moveRecordY.Enqueue(-1);
                timerY = 0;
            }
            else // otherwise keep the timer running
                timerY += Time.deltaTime;
        }

        else // If player was still 
        {
            if (newY != 0) // and now is moving
            {
                timeRecordY.Enqueue(timerY); // Record the new movement
                moveRecordY.Enqueue(0);
                timerY = 0;
            }
            else // otherwise keep the timer running
                timerY += Time.deltaTime;
        }
        lastY = newY; // Record horizontal input

    }

    /// <summary>
    /// Prints out the record player movement
    /// </summary>
    public void PrintRecord()
    {
        print("Started from " + initialPosition);
        print(timeRecordX.Count + " moves horizontally");
        while(timeRecordX.Count > 0)
        {
            print(moveRecordX.Dequeue() + " for " + timeRecordX.Dequeue() + "s");
        }
        print(timeRecordY.Count + " moves vertically");
        while (timeRecordY.Count > 0)
        {
            print(moveRecordY.Dequeue() + " for " + timeRecordY.Dequeue() + "s");
        }
    }

    /// <summary>
    /// Creates a new ghost with the appropriate movement record.
    /// </summary>
    /// <param name="moveSpeed">Provides the movement speed for the new ghost.</param>
    public void CreateGhost(float moveSpeed)
    {
        GhostController newGhost = Instantiate(ghost, initialPosition, Quaternion.identity).GetComponent<GhostController>();
        newGhost.AddRecord(timeRecordX, timeRecordY, moveRecordX, moveRecordY, moveSpeed);
    }
}
