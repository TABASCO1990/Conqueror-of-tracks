using UnityEngine;

public class Fireworks : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _cofetti;

    public static Fireworks instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void StartConfetti()
    {
        foreach (var item in _cofetti)
        {
            item.Play();
        }
    }
}
