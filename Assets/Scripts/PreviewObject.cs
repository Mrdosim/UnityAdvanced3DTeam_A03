using System.Collections.Generic;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    public bool foundation;
    public List<Collider> col = new List<Collider>();
    public Material green;
    public Material red;
    public bool isBuildable;

    public Transform graphics;


    private void Update()
    {
        ChangeColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            col.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            col.Remove(other);
        }
    }

    public void ChangeColor()
    {
        isBuildable = col.Count == 0;

        if ( isBuildable)
        {
            foreach (Transform child in graphics)
            {
                child.GetComponent<Renderer>().material = green;
            }
        }
        else
        {
            foreach(Transform child in graphics)
            {
                child.GetComponent<Renderer>().material = red;
            }
        }
    }
}
