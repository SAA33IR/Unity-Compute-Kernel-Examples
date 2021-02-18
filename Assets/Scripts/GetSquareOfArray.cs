using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetSquareOfArray : MonoBehaviour
{
    public ComputeShader compute;
    int[] data = {1, 3, 5, 7, 9, 0, 2, 4, 6, 8};
    void Start()
    {
        ComputeBuffer buffer = new ComputeBuffer(data.Length, sizeof(int));
        compute.SetBuffer(0, "buffer1", buffer);
        buffer.SetData(data);
        
        compute.Dispatch(0, data.Length, 1, 1);
        buffer.GetData(data);

        for (int i = 0; i < data.Length; i++)
        {
            Debug.Log(data[i]);
        }

        buffer.Release();
    }
}
