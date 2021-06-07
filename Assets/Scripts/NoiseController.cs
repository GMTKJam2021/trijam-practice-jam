using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseController : MonoBehaviour
{
    [SerializeField] private float noiseRadius;
    [SerializeField] private float noiseDuration;
    private CircleCollider2D noiseCircle;


    // Start is called before the first frame update
    void Start()
    {
        noiseCircle = GetComponentInChildren<CircleCollider2D>(true);
        noiseCircle.transform.localScale = new Vector3(noiseRadius * 2, noiseRadius * 2, 1);
    }

    /// <summary>
    /// Starts the noise with the given attributes.
    /// </summary>
    public void StartNoise()
    {
        StopAllCoroutines();
        noiseCircle.gameObject.SetActive(true);
        StartCoroutine(NoiseCountdown());
    }

    /// <summary>
    /// Counts down until the noise is done.
    /// </summary>
    IEnumerator NoiseCountdown()
    {
        yield return new WaitForSeconds(noiseDuration);
        noiseCircle.gameObject.SetActive(false);
    }

    /// <summary>
    /// Resets the noise when the player is caught.
    /// </summary>
    public void Reset()
    {
        StopAllCoroutines();
        noiseCircle.gameObject.SetActive(false);
    }
}
