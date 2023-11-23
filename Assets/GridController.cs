using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public int pointsQnty = 10;
    private Vector3[] gridPoints;

    void Start()
    {
        SetGrid();
    }

    void Update()
    {
        
    }

    void SetGrid()
    {
        gridPoints = new Vector3[pointsQnty * pointsQnty * pointsQnty]; //Setea el tamaño del array
        float spaceBetween = 0.5f / pointsQnty; //El espacio se divide por gridSize para que sea proporcional a la cantidad de puntos que agrega en la grid

        for (int i = 0; i < pointsQnty; i++)
        {
            for (int j = 0; j < pointsQnty; j++)
            {
                for (int k = 0; k < pointsQnty; k++)
                {
                    float x = i * spaceBetween;
                    float y = j * spaceBetween;
                    float z = k * spaceBetween;
                    gridPoints[i * pointsQnty * pointsQnty + j * pointsQnty + k] = new Vector3(x, y, z); //Rellena las posiciones del array desde z (0, 0, 0), (0, 0, 1)
                }
            }
        }
    }

    public Vector3[] GetPoints()
    {
        return gridPoints;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (gridPoints != null)
        {
            foreach (Vector3 point in gridPoints)
            {
                Gizmos.DrawSphere(point, 0.01f);
            }
        }
    }
}
