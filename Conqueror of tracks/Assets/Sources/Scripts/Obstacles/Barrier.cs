using UnityEngine;
using DG.Tweening;
using Game;
using Levels;
using Unity.VisualScripting;

public class Barrier : LoseCondition
{
    protected override void Start()
    {
        way = transform.parent.parent.parent.GetComponent<Way>();

        if (IsRotate)
            Rotate();
    }

    private void Rotate()
    {
        transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 5, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
