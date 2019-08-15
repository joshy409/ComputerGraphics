using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CodeCubeUV : MonoBehaviour
{
    private Mesh customMesh;

    Vector3[] verts = new Vector3[24];
    void Start()
    {
        // First, let's create a new mesh
        var mesh = new Mesh();

        // Vertices
        // locations of vertices

        //front
        verts[0] = new Vector3(0, 0, 0);
        verts[1] = new Vector3(0, 1, 0);
        verts[2] = new Vector3(1, 1, 0);
        verts[3] = new Vector3(1, 0, 0);

        //left
        verts[4] = new Vector3(0, 0, 1);
        verts[5] = new Vector3(0, 1, 1);
        verts[6] = new Vector3(0, 1, 0);
        verts[7] = new Vector3(0, 0, 0);

        //right
        verts[8] = new Vector3(1, 0, 0);
        verts[9] = new Vector3(1, 1, 0);
        verts[10] = new Vector3(1, 1, 1);
        verts[11] = new Vector3(1, 0, 1);

        //bottom
        verts[12] = new Vector3(0, 0, 1);
        verts[13] = new Vector3(0, 0, 0);
        verts[14] = new Vector3(1, 0, 0);
        verts[15] = new Vector3(1, 0, 1);

        //Top
        verts[16] = new Vector3(0, 1, 0);
        verts[17] = new Vector3(0, 1, 1);
        verts[18] = new Vector3(1, 1, 1);
        verts[19] = new Vector3(1, 1, 0);

        //back
        verts[20] = new Vector3(1, 0, 1);
        verts[21] = new Vector3(1, 1, 1);
        verts[22] = new Vector3(0, 1, 1);
        verts[23] = new Vector3(0, 0, 1);

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
        indices[8] = 6;

        indices[9] = 4;
        indices[10] = 6;
        indices[11] = 7;

        //right
        indices[12] = 8;
        indices[13] = 9;
        indices[14] = 10;

        indices[15] = 8;
        indices[16] = 10;
        indices[17] = 11;

        //bottom
        indices[18] = 12;
        indices[19] = 13;
        indices[20] = 14;

        indices[21] = 12;
        indices[22] = 14;
        indices[23] = 15;

        //top
        indices[24] = 16;
        indices[25] = 17;
        indices[26] = 18;

        indices[27] = 16;
        indices[28] = 18;
        indices[29] = 19;

        //back
        indices[30] = 20;
        indices[31] = 21;
        indices[32] = 22;

        indices[33] = 20;
        indices[34] = 22;
        indices[35] = 23;

        mesh.triangles = indices;

        // Normals
        // describes how light bounces off the surface (at the vertex level)
        //
        // note that this data is interpolated across the surface of the triangle
        // 1 normal per vertex
        var norms = new Vector3[24];

        //front
        norms[0] = -Vector3.forward;
        norms[1] = -Vector3.forward;
        norms[2] = -Vector3.forward;
        norms[3] = -Vector3.forward;

        //left
        norms[4] = -Vector3.right;
        norms[5] = -Vector3.right;
        norms[6] = -Vector3.right;
        norms[7] = -Vector3.right;

        //right
        norms[8] = Vector3.right;
        norms[9] = Vector3.right;
        norms[10] = Vector3.right;
        norms[11] = Vector3.right;

        //bottom
        norms[12] = -Vector3.up;
        norms[13] = -Vector3.up;
        norms[14] = -Vector3.up;
        norms[15] = -Vector3.up;

        //top
        norms[16] = Vector3.up;
        norms[17] = Vector3.up;
        norms[18] = Vector3.up;
        norms[19] = Vector3.up;

        //back
        norms[20] = Vector3.forward;
        norms[21] = Vector3.forward;
        norms[22] = Vector3.forward;
        norms[23] = Vector3.forward;

        mesh.normals = norms;

        // UVs, STs
        // defines how textures are mapped onto the surface
        // 1 UV per vertex
        var UVs = new Vector2[24];

        //front
        UVs[0] = new Vector2(0, 0);
        UVs[1] = new Vector2(0, 1);
        UVs[2] = new Vector2(1, 1);
        UVs[3] = new Vector2(1, 0);

        //left
        UVs[4] = new Vector2(0, 0);
        UVs[5] = new Vector2(0, 1);
        UVs[6] = new Vector2(1, 1);
        UVs[7] = new Vector2(1, 0);

        //right
        UVs[8] = new Vector2(0, 0);
        UVs[9] = new Vector2(0, 1);
        UVs[10] = new Vector2(1, 1);
        UVs[11] = new Vector2(1, 0);

        //bottom
        UVs[12] = new Vector2(0, 0);
        UVs[13] = new Vector2(0, 1);
        UVs[14] = new Vector2(1, 1);
        UVs[15] = new Vector2(1, 0);

        //top
        UVs[16] = new Vector2(0, 0);
        UVs[17] = new Vector2(0, 1);
        UVs[18] = new Vector2(1, 1);
        UVs[19] = new Vector2(1, 0);

        //left
        UVs[20] = new Vector2(0, 0);
        UVs[21] = new Vector2(0, 1);
        UVs[22] = new Vector2(1, 1);
        UVs[23] = new Vector2(1, 0);

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
