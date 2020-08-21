using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MpWorld
{
    private int amountRegions = 3;
    private MpRegion[] regions;
    private MpTile[] tiles;

    internal void CreateTiles(HexCell[] cells)
    {
        tiles = new MpTile[cells.Length];
        for(int i=0; i < cells.Length; i++)
        {
            tiles[i] = new MpTile(cells[i]);
        }
        for (int i = 0; i < cells.Length; i++)
        {
            tiles[i].AssignNeighbours(); ;
        }

    }

    internal void AssignRegions()
    {
        if (amountRegions > tiles.Length - 1) 
            amountRegions = tiles.Length - 1;
        
        regions = new MpRegion[amountRegions];
        //Initital region starting positions
        for (int i = 0; i < amountRegions; i++)
        {
            regions[i] = new MpRegion();
            int tileId = UnityEngine.Random.Range(0, tiles.Length);
            while (tiles[tileId].Region != null)
            {
                tileId = UnityEngine.Random.Range(0, tiles.Length);
                
            }
            regions[i].AddTile(tiles[tileId]);
            regions[i].StartingTile=tiles[tileId];

        }
        
        
        int regionsThatCanExpand=1;
        while (regionsThatCanExpand > 0)
        {

            regionsThatCanExpand = 0;
            for (int i = 0; i < amountRegions; i++)
            {
                if (regions[i].Expand())
                {
                    regionsThatCanExpand++;
                }
            }
        }
        int count = 0;
        for(int i=0; i < tiles.Length; i++)
        {
            if(tiles[i].Region == null)
            {
                count++;
            }
        }

        
    }

    internal void EvaluateBiomes()
    {
        
    }

    internal void EvaluatePlateTectonics()
    {
        
    }
}
