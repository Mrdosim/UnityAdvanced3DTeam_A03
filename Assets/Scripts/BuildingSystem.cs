using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    // 현재 위치를 저장하는 변수
    private Vector3 currentPosition;

    // 현재 미리보기 오브젝트의 Transform
    public Transform currentPreview;

    // 카메라의 Transform
    public Transform cam;

    // RaycastHit 정보 저장
    public RaycastHit hit;

    // 레이어 마스크 (레이캐스트가 충돌할 레이어 설정)
    public LayerMask layerMask;

    // 오프셋 및 그리드 크기
    public float offset = 1.0f;
    public float gridSize = 1.0f;

    // 건축 중인지 여부를 나타내는 플래그
    public bool isBuilding;

    // 히트된 면의 방향
    public MCFace dir;

    // UI 인벤토리와 선택된 아이템 정보
    public UIInventory inventory;
    public ItemData selectedItem;

    private void Update()
    {
        // 건축 모드일 때 실행되는 코드
        if (isBuilding)
        {
            // 현재 미리보기가 없고 선택된 아이템이 있을 경우 미리보기 변경
            if (currentPreview == null && selectedItem != null)
            {
                ChangeCurrentBuilding(selectedItem);
            }

            // 미리보기 시작
            StartPreview();
            // 미리보기 회전
            RotatePreview();
        }

        // 마우스 왼쪽 버튼 클릭 시 건축 실행
        if (Input.GetMouseButtonDown(0) && currentPreview != null)
        {
            Build();
        }
    }

    // 현재 건축할 아이템 변경
    public void ChangeCurrentBuilding(ItemData item)
    {
        // 기존 미리보기 오브젝트 삭제
        if (currentPreview != null)
        {
            Destroy(currentPreview.gameObject);
        }

        // 새로운 미리보기 오브젝트 생성
        GameObject curPrev = Instantiate(item.previewPrefab, currentPosition, Quaternion.identity) as GameObject;
        currentPreview = curPrev.transform;
    }

    // 미리보기 시작
    public void StartPreview()
    {
        // 레이캐스트 실행
        if (Physics.Raycast(cam.position, cam.forward, out hit, 3, layerMask))
        {
            // 레이캐스트가 다른 오브젝트와 충돌할 때 미리보기 표시
            if (hit.transform != this.transform)
            {
                ShowPreview(hit);
            }
        }
    }

    // 미리보기 표시
    public void ShowPreview(RaycastHit hit2)
    {
        // 아이템 종류가 바닥일 경우 방향에 따라 위치 조정
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

        // 위치를 그리드에 맞추어 조정
        currentPosition -= Vector3.one * offset;
        currentPosition /= gridSize;
        currentPosition = new Vector3(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y), Mathf.Round(currentPosition.z));
        currentPosition *= gridSize;
        currentPosition += Vector3.one * offset;

        // 미리보기 오브젝트 위치 설정
        currentPreview.position = currentPosition;
    }

    // 건축 실행
    public void Build()
    {
        PreviewObject PO = currentPreview.GetComponent<PreviewObject>();
        if (PO != null && PO.isBuildable)
        {
            // 선택된 아이템의 실제 오브젝트를 현재 위치에 생성
            Instantiate(selectedItem.buildPrefab, currentPosition, currentPreview.rotation);
            isBuilding = false;
            // 미리보기 오브젝트 삭제
            Destroy(currentPreview.gameObject);
        }
    }

    // 건축 취소
    public void CancelBuilding()
    {
        isBuilding = false;
        Destroy(currentPreview.gameObject);
        inventory.RestoreSelectedItem();
    }

    // 미리보기 회전
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

    // 히트된 면의 방향을 반환
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
