using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fifish : MonoBehaviour
{
    [SerializeField] private AudioClip _celebration;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player.Player player))
        {
            Fireworks.instance.StartConfetti();
            AudioSource.PlayClipAtPoint(_celebration,Vector3.zero);
        }
    }
}
