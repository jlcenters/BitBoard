using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public GameObject treePrefab;
    public Text score;
    GameObject[] tiles;
    long dirtBB = 0;
    long desertBB = 0;
    long treeBB = 0;
    long playerBB = 0;



    //generates 8x8 game board upon start
    private void Start()
    {
        tiles = new GameObject[64];
        //board is 8x8
        //each tile is 1x1
        for(int row = 0; row < 8; row++)
        {
            for(int col = 0; col < 8; col++)
            {
                //get random tile
                int ranTile = UnityEngine.Random.Range(0, tilePrefabs.Length);
                //get position based on column and row
                Vector3 pos = new Vector3(col, 0, row);

                //create new tile at specified position with no rotation
                GameObject tile = Instantiate(tilePrefabs[ranTile], pos, Quaternion.identity);

                //rename to "TAG_ROW_COL"
                tile.name = tile.tag + "_" + row + "_" + col;
                tiles[row * 8 + col] = tile;
//debug
                if(tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, row, col);
                }
                else if(tile.tag == "Desert")
                {
                    desertBB = SetCellState(desertBB, row, col);

                }
            }
        }
        InvokeRepeating("PlantTree", 1, 1);
        //Debug.Log("dirtCells: " + CellCount(dirtBB));
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var hitTransform = hit.collider.gameObject.transform;
                int row = (int)hitTransform.position.z;
                int col = (int)hitTransform.position.x;

                if(GetCellState((dirtBB & ~treeBB) | desertBB, row, col))
                {
                    GameObject house = Instantiate(housePrefab);
                    house.transform.parent = hitTransform;
                    house.transform.localPosition = Vector3.zero;

                    playerBB = SetCellState(playerBB, row, col);

                    CalculateScore();
                }
            }
        }
    }



    void PlantTree()
    {
        int randRow = UnityEngine.Random.Range(0, 8);
        int randCol = UnityEngine.Random.Range(0, 8);

        if(GetCellState(~playerBB & dirtBB, randRow, randCol))
        {
            GameObject tree = Instantiate(treePrefab);
            tree.transform.parent = tiles[randRow * 8 + randCol].transform;
            tree.transform.localPosition = Vector3.zero;

            treeBB = SetCellState(treeBB, randRow, randCol);
        }

    }



    bool GetCellState(long bitBoard, int row, int col)
    {
        long mask = 1L << (row * 8 + col);

        return (bitBoard & mask) != 0;
    }



    long SetCellState(long bitBoard, int row, int col)
    {
        //flattens board
        long newBit = 1L << (row * 8 + col);

        return bitBoard |= newBit;
    }



    int CellCount(long bitBoard)
    {
        int count = 0;
        long bb = bitBoard;

        while (bb != 0)
        {
            bb &= bb - 1;
            count++;
        }

        return count;
    }



    void CalculateScore()
    {
        score.text = "Score: " + ((CellCount(dirtBB & playerBB) * 10) + (CellCount(desertBB & playerBB) * 2));

    }






    //DEBUG METHODS
    void PrintBB(string name, long bitBoard)
    {
        Debug.Log(name + ": " + Convert.ToString(bitBoard, 2).PadLeft(64, '0'));
    }

}
