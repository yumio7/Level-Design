using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMaterial : MonoBehaviour
{
    private Color _color;
    private MeshRenderer _rd;
    [SerializeField] private Material mat1;
    [SerializeField] private Material mat2;
    private static readonly int _shaderColor = Shader.PropertyToID("_Color");

    // Start is called before the first frame update
    void Start()
    {
        _rd = gameObject.GetComponent<MeshRenderer>();
        _color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        int rand = Random.Range(0, 2);
        _rd.material = rand != 0 ? mat1 : mat2;
        
        _rd.material.SetColor(_shaderColor, _color);
    }
}
