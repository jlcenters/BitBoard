using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CreateBoard : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject housePrefab;
    public Text score;
    long dirtBB;



    //generates 8x8 game board upon start
    private void Start()
    {
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

                if(tile.tag == "Dirt")
                {
                    dirtBB = SetCellState(dirtBB, row, col);
                    //print location of dirt bitFlag on board
                    //PrintBB("dirtBB", dirtBB);
                }
            }
        }
    }



    void PrintBB(string name, long bitBoard)
    {
        Debug.Log(name + ": " + Convert.ToString(bitBoard, 2).PadLeft(64, '0'));
    }



    long SetCellState(long bitBoard, int row, int col)
    {
        //flattens board
        long newBit = 1L << (row * 8 + col);

        return bitBoard |= newBit;
    }



    int CellCount(long bitBoard)
    {
        return -1;
    }
}
