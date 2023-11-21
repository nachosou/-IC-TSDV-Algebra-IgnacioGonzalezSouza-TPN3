using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject model1; 
    public GameObject model2; 
    public int gridSize = 10; 
    private Vector3[] gridPoints;

    void Start()
    {
        InitializeGrid();
        OnDrawGizmos();
    }

    void Update()
    {
        bool collision = CheckCollisionFigures();

        if (collision)
        {
            Debug.Log("¡Colisión detectada!");
        }
        else
        {
            Debug.Log("No hay colisión.");
        }
    }

    void InitializeGrid()
    {
        gridPoints = new Vector3[gridSize * gridSize * gridSize];
        float spacing = 1f / gridSize;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                for (int k = 0; k < gridSize; k++)
                {
                    float x = i * spacing;
                    float y = j * spacing;
                    float z = k * spacing;
                    gridPoints[i * gridSize * gridSize + j * gridSize + k] = new Vector3(x, y, z);
                }
            }
        }
    }

    bool CheckCollisionFigures()
    {
        foreach (Vector3 point in gridPoints)
        {
            bool insideModel1 = IsPointInsideModel(point, model1);
            bool insideModel2 = IsPointInsideModel(point, model2);

            if (insideModel1 && insideModel2)
            {
                return true;
            }
        }

        return false;
    }

    bool IsPointInsideModel(Vector3 point, GameObject model)
    {
        Mesh mesh = model.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 vertex1 = model.transform.TransformPoint(vertices[triangles[i]]);
            Vector3 vertex2 = model.transform.TransformPoint(vertices[triangles[i + 1]]);
            Vector3 vertex3 = model.transform.TransformPoint(vertices[triangles[i + 2]]);

            Vector3 normal = Vector3.Cross(vertex2 - vertex1, vertex3 - vertex1).normalized;

            if (Vector3.Dot(normal, point - vertex1) > 0)
            {
                return false;
            }
        }

        return true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (gridPoints != null)
        {
            foreach (Vector3 point in gridPoints)
            {
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }

    
}
