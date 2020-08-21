using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpCitizen : MonoBehaviour
{
    private MpNation nationality;
    private int age;
    private MpTile home;
    //ideas: working age interval, basic demand, advanced demand, purchasing power, location

    MpCitizen(MpTile home, MpNation nationality)
    {
        this.home = home;
        this.nationality = nationality;
    }

}
