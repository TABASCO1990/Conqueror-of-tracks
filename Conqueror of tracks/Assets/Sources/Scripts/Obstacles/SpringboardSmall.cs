using UnityEngine;
using DG.Tweening;
using Game;
using System.Linq;

public class SpringboardSmall : MonoBehaviour
{
    private IController _controller;

    private void Start()
    {
        _controller = FindObjectsOfType<MonoBehaviour>().OfType<IController>().First();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player.Player player))
        {    
            DOTween.Sequence().Append(player.transform.DORotate(new Vector3(-11f, 0, 0), 0.1f)).
                Append(player.transform.DOMoveY(1f, 9 / _controller.CurrentSpeed)).
                Append(player.transform.DOMoveY(0f, 0.7f)).
                Append(player.transform.DORotate(Vector3.zero,0.1f)).SetLink(gameObject);           
        }
    }
}
