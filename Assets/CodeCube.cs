using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeCube : MonoBehaviour
{
    private Mesh customMesh;
    Vector3[] verts = new Vector3[8];
    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices
        //verts = new Vector3[6];

        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(0, 1, 0);
        verts[2] = new Vector3(1, 1, 0);
        verts[3] = new Vector3(1, 0, 0);
        verts[4] = new Vector3(0, 0, 1);
        verts[5] = new Vector3(0, 1, 1);
        verts[6] = new Vector3(1, 1, 1);
        verts[7] = new Vector3(1, 0, 1);
        mesh.vertices = verts;

        // Indices
        // determines which vertices make up an individual triangle
        //
        // this should always be a multiple of three
        //
        // each triangle should be specified in _clock-wise_ order
        var indices = new int[36];

        //front
        indices[0] = 0;
        indices[1] = 1;
        indices[2] = 2;

        indices[3] = 0;
        indices[4] = 2;
        indices[5] = 3;

        //left
        indices[6] = 4;
        indices[7] = 5;
        indices[8] = 1;

        indices[9] = 4;
        indices[10] = 1;
        indices[11] = 0;

        //right
        indices[12] = 3;
        indices[13] = 2;
        indices[14] = 6;

        indices[15] = 3;
        indices[16] = 6;
        indices[17] = 7;

        //bottom
        indices[18] = 0;
        indices[19] = 3;
        indices[20] = 4;

        indices[21] = 4;
        indices[22] = 3;
        indices[23] = 7;

        //top
        indices[24] = 1;
        indices[25] = 5;
        indices[26] = 6;

        indices[27] = 1;
        indices[28] = 6;
        indices[29] = 2;

        //back
        indices[30] = 7;
        indices[31] = 6;
        indices[32] = 5;

        indices[33] = 7;
        indices[34] = 5;
        indices[35] = 4;

        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        //
        // note that this data is interpolated across the surface of the triangle
        // 1 normal per vertex
        var norms = new Vector3[8];

        norms[0] = -Vector3.forward;
        norms[1] = -Vector3.forward;
        norms[2] = -Vector3.forward;
        norms[3] = -Vector3.forward;
        norms[4] = -Vector3.forward;
        norms[5] = -Vector3.forward;
        norms[6] = -Vector3.forward;
        norms[7] = -Vector3.forward;

        mesh.normals = norms;

        // UVs, STs
        // defines how textures are mapped onto the surface
        // 1 UV per vertex
        var UVs = new Vector2[8];

        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(1, 1);
        UVs[3] = new Vector2(1, 0);

        UVs[4] = new Vector2(0, 0);
        UVs[5] = new Vector2(0, 1);
        UVs[6] = new Vector2(1, 1);
        UVs[7] = new Vector2(1, 0);

        mesh.uv = UVs;

        var filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;
        customMesh = mesh;
    }

    void OnDestroy()
    {
        if (customMesh != null)
        {
            Destroy(customMesh);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        foreach (var vert in verts)
        {
            Gizmos.DrawSphere(vert + transform.position, .05f);
        }
    }
}
