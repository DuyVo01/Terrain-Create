using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] tracks;
    [SerializeField] private AudioSource audioSource;

    private AudioClip currentTrack;
    private int trackIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentTrack = tracks[trackIndex];
        PlayMusic(currentTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayMusic(AudioClip track)
    {
        audioSource.PlayOneShot(track);
        StartCoroutine(WaitForTrackEnds(track.length));
    }

    IEnumerator WaitForTrackEnds(float trackLength)
    {
        yield return new WaitForSeconds(trackLength);
        trackIndex = (trackIndex + 1) % tracks.Length;
        currentTrack = tracks[trackIndex];
        PlayMusic(currentTrack);
    }

}
