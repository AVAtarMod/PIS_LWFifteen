using System.Collections.Generic;
namespace _3LW
{
    internal class Storage
    {
        private class FieldChange
        {
            private int buttonIndex;
            private Game.Position oldPosition, newPosition;
        }

        private Stack<FieldChange> changes;
    }
}
