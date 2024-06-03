using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public List<buildObjects> objects = new List<buildObjects>();
    public buildObjects currentObject;
    private Vector3 currentPosition;
    public Transform currentPreview;

    public Transform cam;
    public RaycastHit hit;
    public LayerMask layerMask;

    public float offset = 1.0f;
    public float gridSize = 1.0f;

    public bool isBuilding;

    private void Start()
    {
        currentObject = objects[0];
        ChangeCurrentBuilding();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (isBuilding)
        {
            StartPreview();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }

    public void ChangeCurrentBuilding()
    {
        if (currentPreview != null)
        {
            Destroy(currentPreview.gameObject);
        }

        GameObject curPrev = Instantiate(currentObject.preview, currentPosition, Quaternion.identity) as GameObject;
        currentPreview = curPrev.transform;
    }

    public void StartPreview()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 3, layerMask))
        {
            if (hit.transform != this.transform)
            {
                ShowPreview(hit);
            }
        }
    }

    public void ShowPreview(RaycastHit hit2)
    {
        currentPosition = hit2.point;
        currentPosition -= Vector3.one * offset;
        currentPosition /= gridSize;
        currentPosition = new Vector3(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y), Mathf.Round(currentPosition.z));
        currentPosition *= gridSize;
        currentPosition += Vector3.one * offset;
        currentPreview.position = currentPosition;
    }

    public void Build()
    {
        PreviewObject PO = currentPreview.GetComponent<PreviewObject>();
        if (PO != null && PO.isBuildable)
        {
            Instantiate(currentObject.prefab, currentPosition, Quaternion.identity);
        }
    }
}

[System.Serializable]
public class buildObjects
{
    public string name;
    public GameObject prefab;
    public GameObject preview;
    public int gold;
}