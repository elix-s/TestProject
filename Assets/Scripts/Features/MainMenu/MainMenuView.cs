using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _greeting;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private TextMeshProUGUI _counter;
    [SerializeField] private Button _counterButton;
    private int _currentCounter;

    private void Awake()
    {
        _counterButton.onClick.AddListener(UpdateCounter);
    }

    public void UpdateData(string greeting, Sprite buttonSprite, int counter)
    {
        _greeting.text = greeting;
        _buttonImage.sprite = buttonSprite;
        _counter.text = counter.ToString();
        _currentCounter = counter;
    }

    private void UpdateCounter()
    {
        _currentCounter += 1;
        _counter.text = _currentCounter.ToString();
    }
}
