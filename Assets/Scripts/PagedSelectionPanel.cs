using UnityEngine;
using System.Collections.Generic;

public class PagedSelectionPanel : MonoBehaviour
{
    [Header("Item Pooling")]
    public GameObject defaultItemPrefab; // A generic visual item (e.g., a placeholder box or holder)
    public int poolSize = 8;             // Enough for current and next page
    public Transform poolParent;

    public Vector3 holderSize;

    [Header("Slot Transforms")]
    public Transform[] slotTransforms = new Transform[4]; // Assign 4 positions in your scene

    [Header("Item Prefabs")]
    public List<GameObject> itemPrefabs = new List<GameObject>(); // The list of all available 3D items

    private List<GameObject> pooledItems = new List<GameObject>();
    private int currentPage = 0;
    private const int itemsPerPage = 4;

    void Start()
    {
        InitPool();
        UpdatePage();
    }

    void InitPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(defaultItemPrefab, poolParent);
            obj.transform.localScale = holderSize;
            obj.SetActive(false);
            pooledItems.Add(obj);
        }
    }

    public void UpdatePage()
    {
        // Deactivate all pooled items
        foreach (GameObject obj in pooledItems)
            obj.SetActive(false);

        int startIndex = currentPage * itemsPerPage;

        for (int i = 0; i < slotTransforms.Length; i++)
        {
            int itemIndex = startIndex + i;
            if (itemIndex < itemPrefabs.Count)
            {
                GameObject prefabToShow = itemPrefabs[itemIndex];
                GameObject pooledObj = GetPooledObject();

                if (pooledObj == null)
                {
                    Debug.LogWarning("Object pool exhausted!");
                    return;
                }

                // Attach pooled object to slot
                pooledObj.transform.SetParent(slotTransforms[i]);
                pooledObj.transform.localPosition = Vector3.zero;
                pooledObj.transform.localRotation = Quaternion.identity;
                pooledObj.transform.localScale = holderSize;

                // Replace visuals inside pooled object
                ReplaceModel(pooledObj, prefabToShow);

                pooledObj.SetActive(true);
            }
        }
    }

    GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledItems)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null;
    }

    void ReplaceModel(GameObject pooledObject, GameObject newModelPrefab)
    {
        // Clear any previous model
        foreach (Transform child in pooledObject.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate model as child of pooled object
        GameObject newModel = Instantiate(newModelPrefab, pooledObject.transform);
        newModel.transform.localPosition = Vector3.zero;
        newModel.transform.localRotation = Quaternion.identity;
        newModel.transform.localScale = Vector3.one * 1.0f; // Adjust if needed
    }

    public void NextPage()
    {
        int maxPage = Mathf.CeilToInt((float)itemPrefabs.Count / itemsPerPage) - 1;
        if (currentPage < maxPage)
        {
            currentPage++;
            UpdatePage();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdatePage();
        }
    }
}
