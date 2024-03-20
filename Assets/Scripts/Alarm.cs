using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChangeRate;

    private Coroutine _checkCoroutine;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0f;
    }

    public void StartAudio()
    {
        float volume = 1f;

        _audio.Play();
        StopCoroutineChangeVolume();
        _checkCoroutine = StartCoroutine(ChangeVolume(volume));
    }

    public void StopAudio()
    {
        float volume = 0f;
        StopCoroutineChangeVolume();
        _checkCoroutine = StartCoroutine(ChangeVolume(volume));
    }

    private void StopCoroutineChangeVolume()
    {
        if (_checkCoroutine != null)
            StopCoroutine(_checkCoroutine);
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