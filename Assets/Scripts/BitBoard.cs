using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitBoard : MonoBehaviour
{
    private void Update()
    {
    }


    long SetCellState(long bitBoard, int row, int col)
    {
        //new bit will be 1 shifted to the desired location
        long newBit = 1L << (row * 8 + col);

        //returns new bitboard with added piece
        return bitBoard |= newBit;
    }


    //check if there is a piece on the specified location on bitboard
    bool GetCellState(long bitBoard, int row, int col)
    {
        //create mask of potential new layer
        long mask = 1L << (row * 8 * col);
        
        //if mask compared to bitboard is 1 (the space is occupied), return true; else, return false (the space is empty)
        return (mask & bitBoard) != 0L;

    }


    int GetCellCount(long bitBoard)
    {
        int count = 0;
        long bb = bitBoard;

        //iterate while there is at least 1 occupied space
        while(bb != 0)
        {
            //if bb is occupied, removed occupation in instance and add to amt
            bb &= bb - 1;
            count++;
        }

        return count;
    }
}
