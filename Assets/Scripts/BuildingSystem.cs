using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    // ���� ��ġ�� �����ϴ� ����
    private Vector3 currentPosition;

    // ���� �̸����� ������Ʈ�� Transform
    public Transform currentPreview;

    // ī�޶��� Transform
    public Transform cam;

    // RaycastHit ���� ����
    public RaycastHit hit;

    // ���̾� ����ũ (����ĳ��Ʈ�� �浹�� ���̾� ����)
    public LayerMask layerMask;

    // ������ �� �׸��� ũ��
    public float offset = 1.0f;
    public float gridSize = 1.0f;

    // ���� ������ ���θ� ��Ÿ���� �÷���
    public bool isBuilding;

    // ��Ʈ�� ���� ����
    public MCFace dir;

    // UI �κ��丮�� ���õ� ������ ����
    public UIInventory inventory;
    public ItemData selectedItem;

    private void Update()
    {
        // ���� ����� �� ����Ǵ� �ڵ�
        if (isBuilding)
        {
            // ���� �̸����Ⱑ ���� ���õ� �������� ���� ��� �̸����� ����
            if (currentPreview == null && selectedItem != null)
            {
                ChangeCurrentBuilding(selectedItem);
            }

            // �̸����� ����
            StartPreview();
            // �̸����� ȸ��
            RotatePreview();
        }

        // ���콺 ���� ��ư Ŭ�� �� ���� ����
        if (Input.GetMouseButtonDown(0) && currentPreview != null)
        {
            Build();
        }
    }

    // ���� ������ ������ ����
    public void ChangeCurrentBuilding(ItemData item)
    {
        // ���� �̸����� ������Ʈ ����
        if (currentPreview != null)
        {
            Destroy(currentPreview.gameObject);
        }

        // ���ο� �̸����� ������Ʈ ����
        GameObject curPrev = Instantiate(item.previewPrefab, currentPosition, Quaternion.identity) as GameObject;
        currentPreview = curPrev.transform;
    }

    // �̸����� ����
    public void StartPreview()
    {
        // ����ĳ��Ʈ ����
        if (Physics.Raycast(cam.position, cam.forward, out hit, 3, layerMask))
        {
            // ����ĳ��Ʈ�� �ٸ� ������Ʈ�� �浹�� �� �̸����� ǥ��
            if (hit.transform != this.transform)
            {
                ShowPreview(hit);
            }
        }
    }

    // �̸����� ǥ��
    public void ShowPreview(RaycastHit hit2)
    {
        // ������ ������ �ٴ��� ��� ���⿡ ���� ��ġ ����
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

        // ��ġ�� �׸��忡 ���߾� ����
        currentPosition -= Vector3.one * offset;
        currentPosition /= gridSize;
        currentPosition = new Vector3(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y), Mathf.Round(currentPosition.z));
        currentPosition *= gridSize;
        currentPosition += Vector3.one * offset;

        // �̸����� ������Ʈ ��ġ ����
        currentPreview.position = currentPosition;
    }

    // ���� ����
    public void Build()
    {
        PreviewObject PO = currentPreview.GetComponent<PreviewObject>();
        if (PO != null && PO.isBuildable)
        {
            // ���õ� �������� ���� ������Ʈ�� ���� ��ġ�� ����
            Instantiate(selectedItem.buildPrefab, currentPosition, currentPreview.rotation);
            isBuilding = false;
            // �̸����� ������Ʈ ����
            Destroy(currentPreview.gameObject);
        }
    }

    // ���� ���
    public void CancelBuilding()
    {
        isBuilding = false;
        Destroy(currentPreview.gameObject);
        inventory.RestoreSelectedItem();
    }

    // �̸����� ȸ��
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

    // ��Ʈ�� ���� ������ ��ȯ
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
