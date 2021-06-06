using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Color color;
    private SpriteRenderer buttonRend;
    private SpriteRenderer doorRend;
    private BoxCollider2D doorCol;

    void Awake()
    {
        Debug.Assert(door != null);
    }

    private void Start()
    {
        buttonRend = GetComponent<SpriteRenderer>();
        doorRend = door.GetComponent<SpriteRenderer>();
        doorCol = door.GetComponent<BoxCollider2D>();
        color = buttonRend.color;
    }

    /// <summary>
    /// Opens the door associated to the button.
    /// </summary>
    public void Pressed()
    {
        color.a = .1f;
        buttonRend.color = doorRend.color = color;
        doorCol.enabled = false;
    }

    /// <summary>
    /// Starts 3 second countdown to close the door.
    /// </summary>
    public void Unpressed()
    {
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        color.a = .2f;
        buttonRend.color = doorRend.color = color;
        yield return new WaitForSeconds(1f);

        color.a = .3f;
        buttonRend.color = doorRend.color = color;

        yield return new WaitForSeconds(1f);

        color.a = .4f;
        buttonRend.color = doorRend.color = color;

        yield return new WaitForSeconds(1f);

        color.a = 1f;
        buttonRend.color = doorRend.color = color;
        doorCol.enabled = true;
    }

    /// <summary>
    /// Resets the button and door when the player is caught.
    /// </summary>
    public void Reset()
    {
        color.a = 1f;
        buttonRend.color = doorRend.color = color;
        doorCol.enabled = true;
    }
}
