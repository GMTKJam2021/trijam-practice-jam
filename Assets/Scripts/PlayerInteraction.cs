using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            GetComponent<PlayerRecorder>().PrintRecord();

        if (Input.GetKeyDown(KeyCode.G))
            GetComponent<PlayerRecorder>().CreateGhost(10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            collision.GetComponent<ButtonController>().Pressed();
        }

        if (collision.CompareTag("Key"))
        {
            collision.GetComponent<KeyController>().Unlock();
        }

        if (collision.CompareTag("Noise"))
        {
            collision.GetComponent<NoiseController>().StartNoise();
        }

        if (collision.CompareTag("EnemyVision"))
        {
            print("Caught!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Button"))
        {
            collision.GetComponent<ButtonController>().Unpressed();
        }
    }
}
