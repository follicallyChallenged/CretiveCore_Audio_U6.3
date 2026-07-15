using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AnimalSounds : MonoBehaviour
{
    public AudioClip[] sounds;

    [Header("Random Interval (seconds)")]
    public float minTime = 5f;
    public float maxTime = 15f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSounds());
    }

    IEnumerator PlayRandomSounds()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            if (sounds.Length > 0 && !audioSource.isPlaying)
            {
                AudioClip clip = sounds[Random.Range(0, sounds.Length)];
                audioSource.PlayOneShot(clip);
            }
        }
    }
}