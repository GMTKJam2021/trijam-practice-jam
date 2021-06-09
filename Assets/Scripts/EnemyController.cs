using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Vector3[] basePath;
    [SerializeField] private Transform baseTransform;
    private bool onBase;
    private int pathIndex;

    [SerializeField] private Transform target;

    [SerializeField] private float speed = 200f;
    [SerializeField] private float nextWaypointDistance = 1f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;


    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        onBase = true;
        baseTransform.position = basePath[pathIndex];
        UpdatePath(baseTransform);
    }

    void UpdatePath(Transform nextTarget)
    {
        if (seeker.IsDone())
        {
            target = nextTarget;
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onBase = false;
            baseTransform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdatePath(baseTransform);
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            if (onBase)
            {
                pathIndex++;
                if (pathIndex == basePath.Length)
                    pathIndex = 0;
                baseTransform.position = basePath[pathIndex];
                UpdatePath(baseTransform);
            }
            else
                StartCoroutine(LookAround());
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }


        transform.position = Vector2.MoveTowards(transform.position, target.position, .001F * speed);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
            currentWaypoint++;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NoiseCircle"))
        {
            onBase = false;
            UpdatePath(collision.transform);
        }
    }

    IEnumerator LookAround()
    {
        transform.Rotate(new Vector3(0, 0, -1));
        yield return new WaitForSeconds(1);
        transform.Rotate(new Vector3(0, 0, 2));
        yield return new WaitForSeconds(1);
        transform.Rotate(new Vector3(0, 0, -1));
        yield return new WaitForSeconds(1);
        onBase = true;
        baseTransform.position = basePath[pathIndex];
        UpdatePath(baseTransform);
    }
}
