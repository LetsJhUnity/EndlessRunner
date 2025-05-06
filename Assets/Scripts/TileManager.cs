
using System;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    Transform player_transform;
    float spwanZ = 0.0f;
    float length = 6.0f;
    float safeZone = 15.0f;
    int tile_on_screen = 7;

    private List<GameObject> tiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiles = new List<GameObject>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;


        for (int i = 0; i < tile_on_screen; i++)
        {
            Spawn();
        }
    }

    private void Spawn(int prefabIndex = -1)
    {
        var go = Instantiate(tilePrefabs[0]);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spwanZ;
        spwanZ += length;
        tiles.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        if (player_transform.position.z - safeZone > (spwanZ - tile_on_screen * length))
        {
            Spawn();
            Release();
        }
    }

    private void Release()
    {
        Destroy(tiles[0]);
        tiles.RemoveAt(0);
    }
}
