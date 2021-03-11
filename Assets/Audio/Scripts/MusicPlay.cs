using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlay : MonoBehaviour
{
    [SerializeField] private AudioClip[] ArrayOfSongs;
    private AudioSource audioSource; 
    private int NumberOfSong;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        NumberOfSong = Random.RandomRange(0, ArrayOfSongs.Length);
#pragma warning restore CS0618 // Type or member is obsolete
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        while (true)
        {
            audioSource.clip = ArrayOfSongs[NumberOfSong];
            audioSource.Play();
           yield return new WaitForSeconds(audioSource.clip.length);
#pragma warning disable CS0618 // Type or member is obsolete
            NumberOfSong = Random.RandomRange(0, ArrayOfSongs.Length);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }

}

