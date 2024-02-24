using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
    public class CarPolice : Car
    {
        private float _offsetX = 2.5f;

        private void OnEnable()
        {
            StartCoroutine(ChangeLaneRoad(Random.Range(2, 5)));
        }

        protected override void Move()
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        private IEnumerator ChangeLaneRoad(float delay)
        {
            yield return new WaitForSeconds(delay);

            float newPositionX;

            if (transform.position.x < 0)
                newPositionX = transform.position.x + _offsetX;
            else if (transform.position.x > 0)
                newPositionX = transform.position.x - _offsetX;
            else
                newPositionX = transform.position.x + Random.Range(-_offsetX, _offsetX);

            transform.DOMoveX(newPositionX, 2f).SetLink(gameObject);
        }
    }
}
