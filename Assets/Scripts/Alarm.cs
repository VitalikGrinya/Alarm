using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AlarmSound _sound;

    private void OnTriggerEnter(Collider other)
    {
        _sound.StartAudio();
    }

    private void OnTriggerExit(Collider other)
    {
        _sound.StopAudio();
    }
}