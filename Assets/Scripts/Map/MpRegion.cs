using Boo.Lang;
using System;
using System.Collections;
using UnityEngine;


public class MpRegion
{
    private List<MpTile> tiles;
    private Color color;
    private MpTile startingTile;
    private MpNation owner;
    private HexDirection moveDirection;

    public MpRegion()
    {
        tiles = new List<MpTile>();
        this.Color = new Color(UnityEngine.Random.Range(0F, 1F), UnityEngine.Random.Range(0, 1F), UnityEngine.Random.Range(0, 1F)); ;
        MoveDirection = (HexDirection)UnityEngine.Random.Range(0,6);
    }

    public HexDirection MoveDirection { get => moveDirection; set => moveDirection = value; }
    public Color Color { get => color; set => color = value; }
    public MpTile StartingTile { get => startingTile; set => startingTile = value; }

    internal void AddTile(MpTile tile)
    {
        tiles.Add(tile);
        tile.Region = this;
    }

    internal bool Expand()
    {
        List<MpTile> regionLessNeighbours = new List<MpTile>();
        for (int i = 0; i < tiles.Count; i++)
        {
            MpTile tile = tiles[i];
            for (int j = 0; j < tile.Neighbors.Length; j++)
            {
                MpTile neighbour = tile.Neighbors[j];
                if (neighbour != null && neighbour.Region == null)
                {
                    regionLessNeighbours.Add(neighbour);
                }
            }
            
        }
        if (regionLessNeighbours.Count > 0)
        {
            int indexToExpandInto = UnityEngine.Random.Range(0, regionLessNeighbours.Count-1);
            regionLessNeighbours[indexToExpandInto].Region = this;
            AddTile(regionLessNeighbours[indexToExpandInto]);
            
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
