using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshBonesDebug : MonoBehaviour
{
    
    private Transform[] mesh_bones;

    private Vector3[] mesh_bones_positions;

    public bool remove;

    // Start is called before the first frame update
    void Start()
    {
        mesh_bones = GetComponent<SkinnedMeshRenderer>().bones;
        print(this.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {

        if (remove)
        {
            print("removed");
            remove = false;
            RemoveAt(ref mesh_bones, 2);
            print("mesh bones length: " + mesh_bones.Length);
                    for (int i = 0; i < mesh_bones.Length; i++)
        {

            //mesh_bones[i] = null;
            
            Debug.Log(this.gameObject.name + " bone index: " + i + " x: " + mesh_bones[i].transform.position.x + "y: " + mesh_bones[i].transform.position.y + "z: " + mesh_bones[i].transform.position.z);           
        }
        }

    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < mesh_bones.Length; i++)
        {
            Debug.Log("mesh bone transofrm index: " + i + " x: " + mesh_bones[i].transform.position.x + "y: " + mesh_bones[i].transform.position.y + "z: " + mesh_bones[i].transform.position.z);
            Gizmos.DrawCube(new Vector3(mesh_bones[i].transform.position.x, mesh_bones[i].transform.position.y, mesh_bones[i].transform.position.z), new Vector3(0.1f, 0.1f, 0.1f));
        }
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }
}
