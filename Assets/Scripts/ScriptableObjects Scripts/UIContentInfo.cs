using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UIContentInfo", menuName = "UI/Content Information")]
public class UIContentInfo : ScriptableObject
{
    [Header("Content Info")]
    public List<ContentInfoData> contentInfoData;
}
