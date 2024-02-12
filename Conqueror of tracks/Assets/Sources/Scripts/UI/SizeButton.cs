using UnityEngine;
using DG.Tweening;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class SizeButton : MonoBehaviour
    {
        private RectTransform _buttonPlay;

        private void OnEnable()
        {
            _buttonPlay = GetComponent<RectTransform>();
            OnScale();
        }

        private void OnDisable()
        {
            DOTween.Kill(_buttonPlay);
            _buttonPlay.localScale = Vector3.one;
        }

        private void OnScale()
        {
            _buttonPlay.DOScale(new Vector2(1.2f, 1.2f), 0.5f).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
