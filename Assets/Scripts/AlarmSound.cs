using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChangeRate;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0f;
    }

    public void StartAudio()
    {
        float volume = 1f;

        StartCoroutine(ChangeVolume(volume));

        _audio.Play();
    }

    public void StopAudio()
    {
        float volume = 0f;

        StartCoroutine(ChangeVolume(volume));

        if (_audio.volume == volume)
        {
            _audio.Stop();
        }
    }

    private IEnumerator ChangeVolume(float volumeValue)
    {
        while (_audio.volume != volumeValue)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, volumeValue, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }
    }
}