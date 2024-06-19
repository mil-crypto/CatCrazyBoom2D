using UnityEngine;
using UnityEngine.UI;

public class ShowNextSnowFlake : MonoBehaviour
{
    [SerializeField] private SnowInitialize _snowInitialize;
    [SerializeField] private Image _nextSnowFonImage;
    [SerializeField] private Sprite _snow1Sprite, _snow2Sprite, _snow3Sprite;

    private void OnEnable()
    {
        _snowInitialize.PrefInitAction += ShowNext;
    }
    private void OnDisable()
    {
        _snowInitialize.PrefInitAction -= ShowNext;
    }

    private void ShowNext()
    {
        switch (_snowInitialize.NextRandNumber)
        {
            case 1:
                _nextSnowFonImage.sprite = _snow1Sprite;
                break;
            case 2:
                _nextSnowFonImage.sprite = _snow2Sprite;
                break;
            case 3:
                _nextSnowFonImage.sprite = _snow3Sprite;
                break;

        }
    }
}
