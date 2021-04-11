using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Minions : MonoBehaviour
{
    Vector2 targetPos;
    public Vector3Int[] points;
    


    public TileBase[] colors;
    public Tilemap map;
    public Vector3Int topCorner;
    public TileBase tile;
    public int m;
    public int n;
    List<Vector3Int>[] tilesResult;
    
    [Header("Sprites")]
    public Vector2 bottomCorner;
    public int xaxis;
    public int yaxis;
    public Transform pointsParent;
    public Transform instParent;
    public GameObject spritePrefab;

    void Start()
    {
        tilesResult = new List<Vector3Int>[pointsParent.childCount];
        for(int i = 0; i< pointsParent.childCount;i++)
        {
            tilesResult[i] = new List<Vector3Int>();
        }

        //map.SetColor(topCorner, Color.blue);
        Voronoi(topCorner, n, m);
        //Voronoi(bottomCorner, n, m);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTarget()
    {

    }
    
    void Voronoi(Vector3Int topCorner, int n, int m)
    {

        int[] tileCounter = new int[pointsParent.childCount];
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j > -n; j--)
            {
                Vector3Int tilePos = topCorner + new Vector3Int(i, j, 0);
                float closestDist = 1000f;
                int closestPoint = 0;
                for(int d = 0;d< pointsParent.childCount; d++)
                {
                    float dist = (pointsParent.GetChild(d).position - map.CellToWorld(tilePos)).magnitude;

                    if(dist<closestDist)
                    {
                        closestDist = dist;
                        closestPoint = d;
                    }
                    //print(closestPoint);
                    
                }
                //print(closestPoint + " " + closestDist);
                tilesResult[closestPoint].Add(tilePos);
                tileCounter[closestPoint]++;



            }
        }




    }

    public void SetTiles(int Selected)
    {
        List<Vector3Int> list = tilesResult[Selected];
        for (int i = 0; i< list.Count;i++)
        {
            map.SetTile(list[i], colors[0]);
        }
    }
    public void Clear()
    {
        map.ClearAllTiles();
    }

    void printArray<T>(T[] array)
    {
        string f = "[ ";
        for (int i = 0; i < array.Length; i++)
        {
            f += array[i].ToString() + " ";

        }
        f += "]";
        print(f);
    }
    void Voronoi(Vector2 bottomCorner, int xaxis, int axis)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Vector2 tilePos = bottomCorner + new Vector2(i, j);
                float closestDist = 1000f;
                int closestPoint = 0;
                for (int d = 0; d < pointsParent.childCount; d++)
                {
                    float dist = (pointsParent.GetChild(d).position - (Vector3)tilePos).magnitude;

                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closestPoint = d;
                    }
                    print(closestPoint);

                }
                
                float p = (float)closestPoint / (float)pointsParent.childCount;
                print(p + "  " + closestPoint);
                GameObject GO = Instantiate(spritePrefab, tilePos, Quaternion.identity, instParent);
                GO.GetComponent<SpriteRenderer>().color = new Color(p, p, p, 1);
                GO.name = " Point: " + closestPoint;



            }
        }
    }


}
