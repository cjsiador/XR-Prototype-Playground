using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIButtonAnimationData", menuName = "UI/Button Animation Settings")]
public class UIButtonAnimationData : ScriptableObject
{
    [Header("Hover Animation")]
    public float hoverScale = 1.1f;
    public float hoverDuration = 0.3f;

    [Header("Color Animation")]
    public Color normalColor = Color.white;
    public Color hoverColor = Color.gray;
    public Color clickColor = Color.red;
    public float colorDuration = 0.3f;

    [Header("Click Animation")]
    public float clickPunchAmount = 0.1f;
    public float clickDuration = 0.3f;
}
