using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    public List<Collider> col = new List<Collider>();
    public ObjectSort sort;
    public Material green;
    public Material red;
    public bool isBuildable;

    public bool second;

    public PreviewObject childcol;

    public Transform graphics;

    private void Update()
    {
        if (!second)
            ChangeColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            col.Add(other);
            UpdateBuildableState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            col.Remove(other);
            UpdateBuildableState();
        }
    }

    private void UpdateBuildableState()
    {
        if (sort == ObjectSort.Floor)
        {
            // Floor 객체는 다른 객체가 없어도 쌓을 수 있도록 예외 처리
            isBuildable = col.Count == 0 || (childcol != null && childcol.col.Count > 0);
        }
        else
        {
            // 다른 객체는 childcol 조건을 따르도록 수정
            isBuildable = col.Count == 0 && (childcol != null && childcol.col.Count > 0);
        }
    }


    public void ChangeColor()
    {
        UpdateBuildableState();

        if (isBuildable)
        {
            foreach (Transform child in graphics)
            {
                child.GetComponent<Renderer>().material = green;
            }
        }
        else
        {
            foreach (Transform child in graphics)
            {
                child.GetComponent<Renderer>().material = red;
            }
        }
    }
}

public enum ObjectSort
{
    Normal,
    Floor,
    Wall,
    Roof
}