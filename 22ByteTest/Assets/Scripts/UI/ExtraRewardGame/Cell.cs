using Items;

namespace UI.ExtraRewardGame
{
    public struct Cell
    {
        public Cell(int row, int column, ItemType itemType)
        {
            Row = row;
            Column = column;
            ItemType = itemType;
        }

        public int Row { get; }
        public int Column { get; }
        public ItemType ItemType { get; }
    }
}