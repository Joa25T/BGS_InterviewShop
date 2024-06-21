using UnityEngine;

public class OutfitAudioPlay : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    public void PlayAudio()
    {
        _audio.Play();
    }
}
