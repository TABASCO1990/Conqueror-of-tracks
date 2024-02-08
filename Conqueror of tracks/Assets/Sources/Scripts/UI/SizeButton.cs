using UnityEngine;
using DG.Tweening;

public class SizeButton : MonoBehaviour
{
    private void OnEnable()
    {
         OnScale();
    }

    private void OnDisable()
    {
        OnScale();
    }

    private void OnScale()
    {
        transform.DOScale(new Vector2(1.2f, 1.2f), 0.5f).SetLoops(-1, LoopType.Yoyo);
    }
}
