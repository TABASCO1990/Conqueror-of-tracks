using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startScene;
    [SerializeField] private GameObject _soundButtom;

    private void Start()
    {
        _soundButtom.SetActive(true);
    }

    private void OnEnable()
    {
        _startScene.SetActive(true);
        _soundButtom.SetActive(true);
    }

    private void OnDisable()
    {
        if (_startScene != null)
        {
            _startScene.gameObject.SetActive(false);
            _soundButtom.SetActive(false);      
        }         
    } 
}
