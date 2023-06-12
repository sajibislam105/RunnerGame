using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwereveInputSyste : MonoBehaviour
{
    private float moveFactorX;
    private float _lastFingerFramePosition;
    public float MovefactorX => moveFactorX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFingerFramePosition = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - _lastFingerFramePosition;
            _lastFingerFramePosition = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
