using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that represnts a square NxN Matrix
/// </summary>
public class SquareMatrix
{
    public float[,] matrix;

    private float[,] currentMatrix;
    private int n;

    // Constructor and intialization
    public SquareMatrix(List<float> data)
    {
        matrix = new float[data.Count, data.Count];
        currentMatrix = new float[data.Count, data.Count];

        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data.Count; j++)
            {
                currentMatrix[i, j] = data[j];
            }
        }

        n = data.Count;

        //matrix = new float[3, 3];
        //currentMatrix = new float[3, 3];

        //currentMatrix[0, 0] = 0.6f;
        //currentMatrix[0, 1] = 0.3f;
        //currentMatrix[0, 2] = 0.1f;
        //currentMatrix[1, 0] = 0.2f;
        //currentMatrix[1, 1] = 0.3f;
        //currentMatrix[1, 2] = 0.5f;
        //currentMatrix[2, 0] = 0.4f;
        //currentMatrix[2, 1] = 0.1f;
        //currentMatrix[2, 2] = 0.5f;
    }

    // Multiply Matrix with itself
    public void MatrixSquared()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = RowXCol(i,j);
            }
        }
    }

    // Algorithm I made for square matrix mulplication. Called for every element in matrix.
    // Product of Nx1 (row) sub-matrix and 1xN (column) sub-matrix, which is a essentially a sum limited by the matrix's size.
    private float RowXCol(int row, int col)
    {
        float product = 0;

        for (int i = 0; i < n; i++)
        {
            product += currentMatrix[row, i] * currentMatrix[i, col];
            Debug.Log(product);
        }
        return product;
    }
}
