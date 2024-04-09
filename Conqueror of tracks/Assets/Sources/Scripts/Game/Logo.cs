using UnityEngine;
using UnityEngine.UI;
using YG;

public class Logo : MonoBehaviour
{
    [SerializeField] private Image _language;
    [SerializeField] private Sprite[] _sprites;

    private void OnEnable() => YandexGame.GetDataEvent += ChangeSprite;

    private void OnDisable() => YandexGame.GetDataEvent -= ChangeSprite;

    private void Awake()
    {
        if(YandexGame.SDKEnabled == true)
        {
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        switch(YandexGame.EnvironmentData.language)
        {
            case "ru":
                _language.sprite = _sprites[0];
                break;
            case "tr":
                _language.sprite = _sprites[1];
                break;
            default:
                _language.sprite = _sprites[2];
                break;               
        }
    }
}
