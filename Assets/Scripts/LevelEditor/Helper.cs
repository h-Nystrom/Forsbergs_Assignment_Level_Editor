using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor{
    public class Helper{ }
    public enum TileNames{
        Grass,
        Water
    }

    public class Id{
        public int Row{ get; private set; }
        public int Column{ get; private set;}

        public Id(int row, int column){
            Row = row;
            Column = column;
        }

        public override string ToString(){
            return $"({Row},{Column})";
        }
    }
}

