using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public GameObject model1; 
    public GameObject model2;

    [SerializeField] GridController grid;

    void Start()
    {

    }

    void Update()
    {
        bool collision = CheckCollisionFigures();

        if (collision)
        {
            Debug.Log("Collision detected");
        }
        else
        {
            Debug.Log("No collision");
        }
    }

    bool CheckCollisionFigures() //Chequea todos los puntos...
    {
        foreach (Vector3 point in grid.GetPoints())
        {
            bool insideModel1 = model1.GetComponent<Model>().IsPointInsideModel(point);
            bool insideModel2 = model2.GetComponent<Model>().IsPointInsideModel(point);

            if (insideModel1 && insideModel2)
            {
                return true;
            }
        }

        return false;
    }
}
