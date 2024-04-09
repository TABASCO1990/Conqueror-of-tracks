using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using YG;
using System.Collections;

namespace Game
{
    public class Instruction : MonoBehaviour
    {
        [SerializeField] private GameObject _keyboard;
        [SerializeField] private GameObject _mobile;

        public void SetInstruction()
        {
            if (YandexGame.EnvironmentData.isDesktop)
            {
                StartCoroutine(SetAnim(_keyboard));
            }
            else
            {
                StartCoroutine(SetAnim(_mobile));
            }
        }

        private IEnumerator SetAnim(GameObject gameObject)
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }
    }
}
