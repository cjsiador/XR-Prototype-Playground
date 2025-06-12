using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public Animator m_Anim;    

    public void ClosePopupUI()
    {
        StartCoroutine(ClosePopupUICourutine());
    }
    public IEnumerator ClosePopupUICourutine()
    {
        yield return new WaitForSeconds(0.25f);
        m_Anim.Play("PopupUIAnim");
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
}
