using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    public bool foundation;
    public List<Collider> col = new List<Collider>();
    public Material green;
    public Material red;
    public bool isBuildable;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("MeshRenderer not found!");
        }
    }

    private void Update()
    {
        ChangeColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10 && foundation)
        {
            col.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10 && foundation)
        {
            col.Remove(other);
        }
    }

    public void ChangeColor()
    {
        isBuildable = col.Count == 0;

        if (meshRenderer != null)
        {
            Material newMaterial = isBuildable ? new Material(green) : new Material(red);
            meshRenderer.material = newMaterial;
        }
    }
}