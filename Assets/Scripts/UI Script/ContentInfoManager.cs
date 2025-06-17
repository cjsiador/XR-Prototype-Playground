using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ContentInfoManager : MonoBehaviour
{
    public static ContentInfoManager Instance { get; private set; }

    [Header("Index Info")]
    public int contentIndex;
    public int stepIndex;
    public int stepIndexLength;

    [Header("Content Info List")]
    public List<UIContentInfo> uiContentInfoScripts;

    [Header("UI")]
    public Button prevBttn;
    public Button nextBttn;
    public TMP_Text stepText;
    public TMP_Text contentTitleText;
    public TMP_Text contentDescriptionText;

    void Start()
    {
        InstanceButtonListener();
        InstanceContentInfo();
        AssignContentInfo();
    }

    void InstanceButtonListener()
    {
        prevBttn.onClick.AddListener(OnPrevBttnClicked);
        nextBttn.onClick.AddListener(OnNextBttnClicked);
    }

    void InstanceContentInfo()
    {
        stepIndexLength = uiContentInfoScripts[contentIndex].contentInfoData.Count;
    }

    void OnPrevBttnClicked()
    {
        stepIndex--;
        AssignContentInfo();

        Debug.Log("Prev Button Pressed!");
    }

    void OnNextBttnClicked()
    {
        stepIndex++;
        AssignContentInfo();

        Debug.Log("Next Button Pressed!");
    }

    void AssignContentInfo()
    {
        stepText.text = uiContentInfoScripts[contentIndex].contentInfoData[stepIndex].StepTitle;
        contentTitleText.text = uiContentInfoScripts[contentIndex].contentInfoData[stepIndex].ContentTitle;
        contentDescriptionText.text = uiContentInfoScripts[contentIndex].contentInfoData[stepIndex].ContentDescription;

        prevBttn.interactable = stepIndex > 0; // Disables the button if it's less or equal to 0.
        nextBttn.interactable = stepIndex < stepIndexLength - 1; // Disables the button if it's more or equal to stepIndex's length.
    }
}