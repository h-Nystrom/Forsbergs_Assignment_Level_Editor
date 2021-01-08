namespace LevelEditor{
    public class Helper{ }

    public enum TileNames{
        Grass,
        Water
    }

    public class Id{
        public Id(int row, int column){
            Row = row;
            Column = column;
        }

        public int Row{ get; }
        public int Column{ get; }

        public override string ToString(){
            return $"({Row},{Column})";
        }
    }
}