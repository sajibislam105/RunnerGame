using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwereveInputSyste _swereveInputSyste;
    [SerializeField] private float swerveSpeed = 0.5f;
    private float maxSwervespeed = 1f;
    private void Awake()
    {
        _swereveInputSyste = GetComponent<SwereveInputSyste>();
    }

    private void Update()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * _swereveInputSyste.MovefactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwervespeed, maxSwervespeed);
        transform.Translate(swerveAmount,0,0);
    }
}

