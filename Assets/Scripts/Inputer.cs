using System;
using UnityEngine;

public class Inputer : MonoBehaviour
{
    public event Action OnInput;
    private int _clickCount = 0;

    public void Update()
    {

        if (Input.GetMouseButtonDown(_clickCount))
        {
            OnInput?.Invoke();
        }
    }
}