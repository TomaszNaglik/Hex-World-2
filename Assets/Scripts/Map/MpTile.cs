using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpTile 
{
    private MpRegion region;
    private List<MpCitizen> population;
    private HexCell cell;
   
    private MpTile[] neighbors;

    public MpTile(HexCell cell)
    {
        this.cell = cell;
        cell.Tile = this;

        
    }

    public void AssignNeighbours()
    {
        Neighbors = new MpTile[cell.GetNeighbors().Length];
        for (int i = 0; i < Neighbors.Length; i++)
        {
            if(cell.GetNeighbors()[i] != null)
            {
                Neighbors[i] = cell.GetNeighbors()[i].Tile;
            }
            
        }
    }

    public MpRegion Region
    {
        get => region;
        set
        {
            region = value;
            cell.color = value.Color;
        }
    }
    public List<MpCitizen> Population { get => population; set => population = value; }
    public HexCell Cell { get => cell; set => cell = value; }
    public MpTile[] Neighbors { get => neighbors; set => neighbors = value; }

    
    public override string ToString()
    {
        return Cell.coordinates.ToString();
    }
}
