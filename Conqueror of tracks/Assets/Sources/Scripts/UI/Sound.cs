using UnityEngine;
using UnityEngine.UI;
using YG;

public class Sound : MonoBehaviour
{
    [SerializeField] private Image _default;
    [SerializeField] private Sprite _onAudio;
    [SerializeField] private Sprite _offAudio;

    private bool isOn;

    private void Start()
    {
        isOn = YandexGame.savesData.IsSound;
        SetVolume();
    }

    public void OnOffAudio()
    {
        if (!isOn)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }

        YandexGame.savesData.IsSound = isOn;
        SetVolume();
        YandexGame.SaveProgress();
    }

    private void SetVolume()
    {
        AudioListener.volume = isOn ? 1.0f : 0.0f;
        _default.sprite = isOn ? _onAudio : _offAudio;

    }
}
