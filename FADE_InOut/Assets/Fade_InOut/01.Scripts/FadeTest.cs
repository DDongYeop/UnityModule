using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTest : MonoBehaviour
{
    [SerializeField] private Fade_InOut _fadeInOut;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F))
            _fadeInOut.Fade();
    }
}
