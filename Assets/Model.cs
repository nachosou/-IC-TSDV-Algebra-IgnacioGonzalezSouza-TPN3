using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public bool IsPointInsideModel(Vector3 point)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 vertex1 = transform.TransformPoint(vertices[triangles[i]]);
            Vector3 vertex2 = transform.TransformPoint(vertices[triangles[i + 1]]);
            Vector3 vertex3 = transform.TransformPoint(vertices[triangles[i + 2]]);

            Vector3 normal = Vector3.Cross(vertex2 - vertex1, vertex3 - vertex1).normalized; //las normales estan hacia afuera

            if (Vector3.Dot(normal, point - vertex1) > 0)
            {
                return false;
            }
        }

        return true;
    }
}
