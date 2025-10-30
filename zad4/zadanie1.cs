using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public int count = 0;
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    List<GameObject> collectObjekt = new List<GameObject>();

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        Bounds bounds = mesh.bounds;
        Vector3 minWorldCoords = transform.TransformPoint(bounds.min);
        Vector3 maxWorldCoords = transform.TransformPoint(bounds.max);
        Debug.Log(maxWorldCoords.z);
        collectObjekt.Add(block);
        collectObjekt.Add(block1);
        collectObjekt.Add(block2);
        collectObjekt.Add(block3);
        collectObjekt.Add(block4);
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)minWorldCoords.x, (int)maxWorldCoords.x - (int)minWorldCoords.x).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)minWorldCoords.z, (int)maxWorldCoords.z-(int)minWorldCoords.z).OrderBy(x => Guid.NewGuid()).Take(10));
        for (int i = 0; i < count; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 0.5f, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {

        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            int Object = UnityEngine.Random.Range(0, 5);
            Instantiate(this.collectObjekt[Object], this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}