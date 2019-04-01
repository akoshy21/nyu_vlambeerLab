using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaster : MonoBehaviour
{
    private float minX = 0f;
    private float minZ = 0f;
    private float maxX = 0f;
    private float maxZ = 0f;
    public float distX, distZ;

    float tileX, tileZ;

    public Camera mainCam;

    public List<GameObject> tiles;

    private void Update()
    {
        MinMaxDist();
        AdjCamera();
    }

    void MinMaxDist()
    {
        foreach(GameObject ti in tiles)
        {
            tileX = ti.transform.localScale.x/2;
            tileZ = ti.transform.localScale.z/2;

            if(ti.transform.position.x + tileX > maxX)
            {
                maxX = ti.transform.position.x + tileX;
            }
            else if (ti.transform.position.x - tileX < minX)
            {
                minX = ti.transform.position.x - tileX;
            }

            if (ti.transform.position.z + tileZ > maxZ)
            {
                maxZ = ti.transform.position.z + tileZ;
            }
            else if (ti.transform.position.z - tileZ < minZ)
            {
                minZ = ti.transform.position.z - tileZ;
            }
        }

        distX = maxX - minX;
        distZ = maxZ - minZ;
        Debug.Log("min x: " + minX + ", max x:" + maxX);
    }

    void AdjCamera()
    {
        float avgX = minX + (distX/2);
        float avgZ = minZ + (distZ / 2);

        Debug.Log("dist x: " + distX + ", avg x:" + avgX);


        mainCam.transform.position = new Vector3(avgX,33f, avgZ);

        mainCam.orthographicSize = 2 + (distX / 3f);

        if (mainCam.orthographicSize < distZ / 2f) 
        {
            mainCam.orthographicSize = 2 + (distZ / 1.8f);
        }
    }

}
