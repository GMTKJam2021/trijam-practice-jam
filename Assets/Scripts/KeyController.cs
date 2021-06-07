using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private Color color;
    private SpriteRenderer keyRend;
    private SpriteRenderer doorRend;
    private BoxCollider2D doorCol;

    void Awake()
    {
        Debug.Assert(door != null);
    }

    private void Start()
    {
        keyRend = GetComponent<SpriteRenderer>();
        doorRend = door.GetComponent<SpriteRenderer>();
        doorCol = door.GetComponent<BoxCollider2D>();
        color = keyRend.color;
    }

    /// <summary>
    /// Opens the door associated to the key.
    /// </summary>
    public void Unlock()
    {
        color.a = .1f;
        keyRend.enabled = false;
        doorRend.color = color;
        doorCol.enabled = false;
    }

    /// <summary>
    /// Resets the key and door when the player is caught.
    /// </summary>
    public void Reset()
    {
        color.a = 1f;
        keyRend.enabled = true;
        doorRend.color = color;
        doorCol.enabled = true;
    }

}
