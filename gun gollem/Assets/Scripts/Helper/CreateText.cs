using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static TextMesh createWorldText(Transform parent, string text,Vector3 localpos,int fountSize,Color color,TextAnchor textAnchor, TextAlignment textAlignment,int sortingOrder)
    {
        GameObject gameObject = new GameObject("world_text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localpos;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.fontSize = fountSize;
        textMesh.fontSize = fountSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;

    }
}
