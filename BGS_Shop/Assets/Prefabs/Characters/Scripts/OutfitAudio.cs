using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    public void PlayAudio()
    {
        _audio.Play();
    }
}
