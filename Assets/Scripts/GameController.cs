using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameController : MonoBehaviour
{
    public GameObject wallPrefab, deadZonePrefab , Path, Walls;
    public float[] positionsX = new float[1], positionsZ = new float[1];
    bool needToBake = true;
    float x, z;
    void Start()
    {
        Spawn(wallPrefab, 15, 0.5f);
        Spawn(deadZonePrefab, 10, 0);
    }

    void Spawn(GameObject prefab, int count, float y)
    {
        for (int i = 0; i < count; i++)
        {
            /*float potentionalX = Random.Range(-5, 5);
            foreach(float X in positionsX)
            {
                do
                {
                    potentionalX = Random.Range(-5, 5);
                }
                while (potentionalX != X);
                x = potentionalX;
            }
            positionsX.Concat(new float[] { x }).ToArray();
            float potentionalZ = Random.Range(-4, 4);
            foreach (float Z in positionsZ)
            {
                do
                {
                    potentionalZ = Random.Range(-4, 4);
                }
                while (potentionalZ != Z);
                z = potentionalX;
            }
            positionsZ.Concat(new float[] { z }).ToArray();*/
            //x = GeneratePotentional(5, positionsX);
            //z = GeneratePotentional(4, positionsZ);

            Vector3 pos = new Vector3(Random.Range(-5, 5), y, Random.Range(-4, 4));
            Instantiate(prefab, pos, Quaternion.identity, Walls.transform);
        }
        if (needToBake)
        {
            Path.GetComponent<GridBehavior>().gridArray = new GameObject[Path.GetComponent<GridBehavior>().columns, Path.GetComponent<GridBehavior>().rows];
            if (Path.GetComponent<GridBehavior>().gridPrefab)
                Path.GetComponent<GridBehavior>().GenerateGrid();
            needToBake = false;
        }
    }

    float GeneratePotentional(int range, float[] array)
    {
        float potentional = Random.Range(-range, range);
        Debug.Log(potentional);
        foreach (float pot in array)
        {
            do
            {
                potentional = Random.Range(-range, range);
            }
            while (potentional != pot);
        }
        array.Concat(new float[] { potentional}).ToArray();
        return potentional;
    }

    public void Pause_Continue(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
