using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject categoryPanelPivot;
    [SerializeField] float duration = 15f;
    [SerializeField] Quaternion startRot;
    [SerializeField] Quaternion endRot;
    [SerializeField] List<GameObject> selectionSlotList;
    [SerializeField] List<GameObject> selectionPrefabListt;


    void OnEnable()
    {
        OpenAnimation();
    }

    void OpenAnimation()
    {
        categoryPanelPivot.transform.rotation = startRot;
        StartCoroutine(PanelAnimation(endRot));
    }

    void CloseAnimation()
    {
        categoryPanelPivot.transform.rotation = endRot;
        StartCoroutine(PanelAnimation(startRot));
    }

    IEnumerator PanelAnimation(Quaternion targetRot)
    {
        float timer = 0;
        float t = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            t = timer / duration;

            categoryPanelPivot.transform.rotation = Quaternion.Lerp(categoryPanelPivot.transform.rotation, targetRot, t);

            yield return null;
        }

        yield return null;
    }
}
