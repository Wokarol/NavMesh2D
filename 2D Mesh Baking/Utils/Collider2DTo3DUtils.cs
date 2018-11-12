using System;
using UnityEngine;

namespace Wokarol.NavMesh2D
{
    internal static class Collider2DTo3DUtils
    {
        internal static Mesh GetMeshFromPath(Vector2[] path)
        {
            var mesh = new Mesh();
            var verts = new Vector3[path.Length * 2];
            var tris = new int[path.Length * 6];
            int max = verts.Length;
            for (int i = 0; i < path.Length; i++) {
                int n = i * 2;
                verts[n] = (Vector3)path[i] + (Vector3.back * 20);
                verts[n + 1] = (Vector3)path[i] + (Vector3.back * -20);

                int tIndex = i * 6;
                tris[tIndex] = n;
                tris[tIndex + 1] = n + 1;
                tris[tIndex + 2] = (n + 2) % max;
                tris[tIndex + 3] = (n + 2) % max;
                tris[tIndex + 4] = n + 1;
                tris[tIndex + 5] = (n + 3) % max;
            }


            mesh.vertices = verts;
            mesh.triangles = tris;
            return mesh;
        }

        internal static GameObject CreateLine(Vector2 a, Vector2 b, float edgeRadius, Transform parent)
        {
            var obj = new GameObject($"Line ({a.ToString()}) -> ({b.ToString()}) _NMClone");
            obj.transform.parent = parent;
            obj.transform.localPosition = Vector3.zero;

            var v = b - a;
            obj.transform.localPosition = a + (v * .5f);

            var box = obj.AddComponent<BoxCollider>();
            box.size = new Vector3(edgeRadius, v.magnitude, 20);

            var angle = Vector2.Angle(Vector2.up, -v);
            obj.transform.rotation = Quaternion.Euler(0, 0, angle);

            return obj;
        }
    } 
}