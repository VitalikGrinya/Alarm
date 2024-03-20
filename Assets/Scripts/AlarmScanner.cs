using System.Collections;
using UnityEngine;

public class AlarmScanner : MonoBehaviour
{
    [SerializeField] private Alarm _sound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Thief thief))
            _sound.StartAudio();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out Thief thief))
            _sound.StopAudio();
    }
}