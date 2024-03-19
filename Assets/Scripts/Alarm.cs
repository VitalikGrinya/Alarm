using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _volumeChangeRate;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        float volumeValue = 1f;

        StartCoroutine(ChangeVolume(volumeValue));
        _audio.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        float volumeValue = 0f;

        StartCoroutine(ChangeVolume(volumeValue));
        _audio.Play();
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