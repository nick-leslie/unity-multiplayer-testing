using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungionGenaration : MonoBehaviour
{
    public int runs=10;
    public GameObject room;
    public List<Vector2Int> visted = new List<Vector2Int>();
    // Start is called before the first frame update
    void Start()
    {
        genarate();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            genarate();
        }
    }
    void genarate()
    {
        Grid grid = new Grid(10, 10, 10f);
        Vector2Int pos = new Vector2Int(5, 5);
        grid.setNum(pos, 1);
        Instantiate(room, grid.getCenterOfCell(pos), room.transform.rotation);
        visted.Add(pos);
        for (int i = 0; i < runs; i++)
        {
            bool seen = false;
            pos += RandomDire();
            for (int j = 0; j < visted.Count; j++)
            {
                if (Vector2Int.Distance(pos, visted[j]) == 0)
                {
                    Debug.Log("got");
                    seen = true;
                }
            }
            //Debug.Log(pos);
            if (seen == false)
            {
                grid.setNum(pos, grid.GetNum(pos) + 1);
                visted.Add(pos);
                Instantiate(room, grid.getCenterOfCell(pos), room.transform.rotation);
            }
            else
            {
                i -= 1;
            }
        }
        //Grid tiles = new Grid(40, 20, 1f);
    }
    Vector2Int RandomDire()
    {
        int x=0;
        int y=0;
        int coinFlip;
        //see wich random is chosen first
        coinFlip = Random.Range(0, 2);
        Debug.Log(coinFlip);
        if (coinFlip < 1)
        {
            //X has priority  
            x = Random.Range(-1, 2);
            while (x == 0 && y == 0)
            {
                x = Random.Range(-1, 2);
            }
        }
        else
        {
            y = Random.Range(-1, 2);

            while (x == 0 && y == 0)
            {
                y = Random.Range(-1, 2);
            }
        }
        return new Vector2Int(x, y);
    }
}
