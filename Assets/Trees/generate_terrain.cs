using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate_terrain : MonoBehaviour
{
    private int minVertices = 3;
    private int maxVertices = 12;
    private int minDistance = 2;
    private int maxDistance = 10;
    private int maxPeaks = 8;
    private int height = 10;

    private List<Vector3> polygon(int minVertices, int maxVertices, int minDistance, int maxDistance, Vector3 center, int height)
    {
        int vertices = Random.Range(minVertices, maxVertices);
        Vector3 lastVector = center;



        List<Vector3> polygon = new List<Vector3>();

        for (int i = 0; i < vertices; i++)
        {
            int distance = (int)lastVector.magnitude + Random.Range(minDistance, maxDistance) / 2;
            float cartesian = distance * Mathf.Sqrt(2);
            Vector3 newVector = new Vector3(cartesian + center.x/2, cartesian + center.y/2, height);
            int rotateX = Random.Range(0, 1) * -1;
            int rotateY = Random.Range(0, 1) * -1;

            newVector.x *= rotateX;
            newVector.y *= rotateY;

            lastVector = newVector;
            polygon.Add(newVector);
        }

        return polygon;
    }

    struct layer
    {
        public int maxDistance;
        public int maxVertices;
    }

    // Start is called before the first frame update
    void Start()
    {
        int maxPeaks = this.maxPeaks;
        Mesh terrain = GameObject.Find("Terrain").GetComponent<Mesh>();

        layer lastLayer = new layer();
        lastLayer.maxDistance = this.maxDistance;
        lastLayer.maxVertices = this.maxVertices;

        for (int i = 0; i < height; i++)
        {
            int peaks = Random.Range(0, maxPeaks);

            for (int j = 0; j < maxPeaks; j++)
            {

            }

            maxPeaks /= 2;
        }
 //       terrain.vertices =
  //      terrain.terrainData.heightmapTexture
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
