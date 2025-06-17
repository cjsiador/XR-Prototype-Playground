using PassthroughCameraSamples;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WebcamTextureAssigner : MonoBehaviour
{
    IEnumerator Start()
    {
        WebCamTextureManager webCamTextureManager = null;
        WebCamTexture webCamTexture = null;

        do
        {
            yield return null;

            if (webCamTextureManager == null)
            {
                webCamTextureManager = FindFirstObjectByType<WebCamTextureManager>();
            }
            else
            {
                webCamTexture = webCamTextureManager.WebCamTexture;
            }
        } while (webCamTexture == null);

        GetComponent<Renderer>().material.mainTexture = webCamTexture;
    }
}