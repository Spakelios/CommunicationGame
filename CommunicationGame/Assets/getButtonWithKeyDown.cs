using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getButtonWithKeyDown : MonoBehaviour
{
    
    public KeyCode key;
    public Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            _button.onClick.Invoke();
        }
    }
}