using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fifish : MonoBehaviour
{
    [SerializeField] private AudioClip _celebration;
    [SerializeField] private ParticleSystem[] _confettis;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player.Player player))
        {
            foreach (ParticleSystem confettis in _confettis)
            {
                confettis.Play();
            }

            AudioSource.PlayClipAtPoint(_celebration,Vector3.zero);
        }
    }
}
