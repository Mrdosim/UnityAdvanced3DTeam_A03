using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    //public List<buildObjects> objects = new List<buildObjects>();
    //public buildObjects currentObject;
    private Vector3 currentPosition;
    public Transform currentPreview;

    public Transform cam;
    public RaycastHit hit;
    public LayerMask layerMask;

    public float offset = 1.0f;
    public float gridSize = 1.0f;

    public bool isBuilding;

    public MCFace dir;
    public UIInventory inventory;
    public ItemData selectedItem;

    private void Update()
    {
        if (isBuilding)
        {
            if (currentPreview == null && selectedItem != null)
            {
                ChangeCurrentBuilding(selectedItem);
            }

            StartPreview();
            RotatePreview();
        }

        if (Input.GetMouseButtonDown(0) && currentPreview != null)
        {
            Build();
        }
    }

    public void ChangeCurrentBuilding(ItemData item)
    {
        if (currentPreview != null)
        {
            Destroy(currentPreview.gameObject);
        }

        GameObject curPrev = Instantiate(item.previewPrefab, currentPosition, Quaternion.identity) as GameObject;
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
        if (selectedItem.sort == ObjectSort.Floor)
        {
            dir = GetHitFace(hit2);
            if (dir == MCFace.Up || dir == MCFace.Down)
            {
                currentPosition = hit2.point;
            }
            else
            {
                if (dir == MCFace.North)
                {
                    currentPosition = hit2.point + new Vector3(0, 0, 0.5f);
                }
                if (dir == MCFace.South)
                {
                    currentPosition = hit2.point + new Vector3(0, 0, -0.5f);
                }
                if (dir == MCFace.East)
                {
                    currentPosition = hit2.point + new Vector3(0.5f, 0, 0);
                }
                if (dir == MCFace.West)
                {
                    currentPosition = hit2.point + new Vector3(-0.5f, 0, 0);
                }
            }
        }
        else
        {
            currentPosition = hit2.point;
        }
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
            Instantiate(selectedItem.buildPrefab, currentPosition, currentPreview.rotation);
            isBuilding = false; // 건축 모드 종료
            Destroy(currentPreview.gameObject); // 미리보기 객체 제거
        }
    }

    public void CancelBuilding()
    {
        isBuilding = false;
        Destroy(currentPreview.gameObject);
        inventory.RestoreSelectedItem();
    }

    public void RotatePreview()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0)
        {
            currentPreview.Rotate(Vector3.up, 90, Space.World);
        }
        else if (scrollInput < 0)
        {
            currentPreview.Rotate(Vector3.up, -90, Space.World);
        }
    }

    public static MCFace GetHitFace(RaycastHit hit)
    {
        Vector3 incomingVec = hit.normal - Vector3.up;

        if (incomingVec == new Vector3(0, -1, -1))
        {
            return MCFace.South;
        }
        if (incomingVec == new Vector3(0, -1, 1))
        {
            return MCFace.North;
        }
        if (incomingVec == new Vector3(0, 0, 0))
        {
            return MCFace.Up;
        }
        if (incomingVec == new Vector3(1, 1, 1))
        {
            return MCFace.Down;
        }
        if (incomingVec == new Vector3(-1, -1, 0))
        {
            return MCFace.West;
        }
        if (incomingVec == new Vector3(1, -1, 0))
        {
            return MCFace.East;
        }

        return MCFace.None;
    }
}

//[System.Serializable]
//public class buildObjects
//{
//    public string name;
//    public GameObject prefab;
//    public ObjectSort sort;
//    public GameObject preview;
//    public int gold;
//}

public enum MCFace
{
    None,
    Up,
    Down,
    East,
    West,
    North,
    South
}