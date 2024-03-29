﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grid
{
    public int  Width{get{ return width; }}
    public int Height { get { return height; } }

    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] textArry;
    public Grid(int _width,int _height,float _cellSize)
    {
        if (_height <= 1)
        {
            _height = 1;
        }
        if (_width <= 1)
        {
            _width = 1;
        }  
        height = _height - 1;
        width = _width -1 ;


        cellSize = _cellSize;
        gridArray = new int[width, height];
        textArry = new TextMesh[width, height];
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
              //  textArry[x,y] = CreateText.createWorldText(null, gridArray[x,y].ToString(),getCenterOfCell(x,y), 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 1);
               // CreateText.createWorldText(null,x.ToString()+","+y.ToString(), getWorldPos(x, y) + new Vector3(cellSize, cellSize) * .5f + Vector3.down*.5f, 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 1);
                Debug.DrawLine(getWorldPos(x, y), getWorldPos(x + 1, y), Color.white,100f);
                Debug.DrawLine(getWorldPos(x, y), getWorldPos(x, y+1), Color.white,100f);
            }
        }
        Debug.DrawLine(getWorldPos(0, height), getWorldPos(width, height), Color.white, 100f);
        Debug.DrawLine(getWorldPos(width,0), getWorldPos(width, height), Color.white, 100f);
    }
    public Vector3 getWorldPos(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }
    public Vector3 getCenterOfCell(int x,int y)
    {
         return getWorldPos(x, y) + new Vector3(cellSize, cellSize) * .5f;
    }
    public Vector3 getCenterOfCell(Vector2Int cords)
    {
        return getWorldPos(cords.x, cords.y) + new Vector3(cellSize, cellSize) * .5f;
    }
    public void setNum(int x,int y,int num)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = num;
            //textArry[x, y].text = num.ToString();
        }
    }
    public void setNum(Vector2Int cords, int num)
    {
        if (cords.x >= 0 && cords.y >= 0 && cords.x < width && cords.y < height)
        {
            gridArray[cords.x, cords.y] = num;
            //textArry[cords.x, cords.y].text = num.ToString();
        }
    }
    public int GetNum(int x,int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        //out of bounds
        return -1;
    }
    public int GetNum(Vector2Int cords)
    {
        if (cords.x >= 0 && cords.y >= 0 && cords.x < width && cords.y < height)
        {
            return gridArray[cords.x, cords.y];
        }
        //out of bounds
        return -1;
    }
    public bool getValidNaborPos(Vector2Int pos,ref List<Vector2Int> nabor)
    {

        if (GetNum(pos.x+1,pos.y) == 0)
        {
            nabor.Add(new Vector2Int(pos.x+1,pos.y));
        }
        if (GetNum(pos.x-1,pos.y) == 0)
        {
            nabor.Add(new Vector2Int(pos.x-1,pos.y));
        }
        if (GetNum(pos.x,pos.y+1) == 0)
        {
            nabor.Add(new Vector2Int(pos.x,pos.y+1));
        }
        if (GetNum(pos.x,pos.y-1) == 0)
        {
            nabor.Add(new Vector2Int(pos.x,pos.y-1));
        }
        if (nabor.Count>0)
        {
            return true;
        }
        return false;
    }
    public int[] getfourNaboringCellsInfo(Vector2Int pos)
    {
        List<int> nabor = new List<int>();
        if (GetNum(new Vector2Int(pos.x+1,pos.y)) != -1)
        {
            nabor.Add(gridArray[pos.x + 1, pos.y]);
        }
        if (GetNum(new Vector2Int(pos.x-1,pos.y)) != -1)
        {
            nabor.Add(gridArray[pos.x-1,pos.y]);
        }
        if (GetNum(new Vector2Int(pos.x,pos.y+1)) != -1)
        {
            nabor.Add(gridArray[pos.x,pos.y+1]);
        }
        if (GetNum(new Vector2Int(pos.x,pos.y-1)) != -1)
        {
            nabor.Add(gridArray[pos.x, pos.y - 1]);
        }
        return nabor.ToArray();
    }
    public bool CheckUPForNabor(Vector2Int pos)
    {
        if (GetNum(new Vector2Int(pos.x, pos.y + 1)) > 0)
        {
            return true;
        }
        else
        {
            // no  nabor
            return false;
        }
    }
    public bool CheckDownForNabor(Vector2Int pos)
    {
        if (GetNum(new Vector2Int(pos.x, pos.y - 1)) >0)
        {
            return true;
        }
        else
        {
            // no  nabor
            return false;
        }
    }
    public bool CheckRightForNabor(Vector2Int pos)
    {
        if (GetNum(new Vector2Int(pos.x - 1, pos.y)) >0)
        {
            return true;
        }
        else
        {
            // no  nabor
            return false;
        }
    }
    public bool CheckLeftForNabor(Vector2Int pos)
    {
        if (GetNum(new Vector2Int(pos.x + 1, pos.y)) > 0)
        {
            return true;
        }
        else
        {
            // no  nabor
            return false;
        }
    }
}
