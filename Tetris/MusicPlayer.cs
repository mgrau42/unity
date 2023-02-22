using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script plays music using an AudioSource component attached to this object.
// It has a public method PlayMusic that can be called to play the audio clip, but only if it's not already playing.
public class MusicPlayer : MonoBehaviour
{
	// Find and cache the AudioSource component on Awake.
     private AudioSource _audioSource;
     private void Awake()
     {
         _audioSource = GetComponent<AudioSource>();
     }
 
	// Play the audio clip only if it's not already playing.
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
}
