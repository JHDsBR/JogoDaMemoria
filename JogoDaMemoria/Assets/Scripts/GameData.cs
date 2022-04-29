using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{
    public int maxLevel;
    public int numberOfCardsTurned;
    // public int lifes;

    public GameData(GameDataManager data)
    {
        maxLevel = data.maxLevel;
        numberOfCardsTurned = data.numberOfCardsTurned;
        // lifes = data.lifes;
    }


}
