using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class SelectionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler
{
    [Header("Animation Config")]
    public UIButtonAnimationData animationData;

    public GameObject selectionObj;

    [SerializeField]
    private GameObject selectionParentObj;

    [SerializeField]
    private GameObject selectionPanel;

    private Vector3 originalScale;
    private Tween currentTween;
    private Tween colorTween;

    private Renderer targetRenderer;
    private Material instanceMaterial;

    void Awake()
    {
        originalScale = selectionParentObj.transform.localScale;
        targetRenderer = selectionPanel.GetComponent<Renderer>();

        instanceMaterial = new Material(selectionPanel.GetComponent<Renderer>().material);
        targetRenderer.material = instanceMaterial;

        instanceMaterial.color = animationData.normalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Released");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Started Holding");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        currentTween?.Kill();
        colorTween?.Kill();

        currentTween = selectionParentObj.transform.DOScale(originalScale * animationData.hoverScale, animationData.hoverDuration).SetEase(Ease.OutBack);
        colorTween = instanceMaterial.DOColor(animationData.hoverColor, animationData.colorDuration);

        Debug.Log("Pointer Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        currentTween?.Kill();
        colorTween?.Kill();

        currentTween = selectionParentObj.transform.DOScale(originalScale, animationData.hoverDuration).SetEase(Ease.OutExpo);
        colorTween = instanceMaterial.DOColor(animationData.normalColor, animationData.colorDuration);

        Debug.Log("Pointer Exit");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selectionParentObj.transform.DOPunchScale(Vector3.one * animationData.clickPunchAmount, animationData.clickDuration, 8, 0.5f);

        Sequence colorPunchSeq = DOTween.Sequence();

        colorPunchSeq.Append(instanceMaterial.DOColor(animationData.clickColor, animationData.colorDuration * 0.5f));
        colorPunchSeq.Append(instanceMaterial.DOColor(animationData.normalColor, animationData.colorDuration * 0.5f));

        Debug.Log("Pointer Click");
    }
}
