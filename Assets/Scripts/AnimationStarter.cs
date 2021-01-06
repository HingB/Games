 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStarter : MonoBehaviour
{
    public void StartAnimation(Animation animation)
    {
        animation.Play();
    }
}
