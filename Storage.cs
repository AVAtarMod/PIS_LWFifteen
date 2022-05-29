using System.Collections.Generic;
namespace _3LW
{
    internal class Storage
    {
        public struct FieldChange
        {
            public uint OldPosition { get; private set; }
            public uint NewPosition { get; private set; }

            public FieldChange(GamePosition from, GamePosition to)
            {
                OldPosition = from;
                NewPosition = to;
            }
        }

        private List<FieldChange> _changesHistory;
        private int _current, _end;
        private bool _empty = true;

        public Storage()
        {
            _changesHistory = new List<FieldChange>();
            _end = _changesHistory.Count;
            _current = _end;
        }

        public bool IsExistPreviousMove() => _current >= 0 && !_empty;

        public FieldChange GetPreviousMove()
        {
            if (_current >= 0 && !_empty)
            {
                FieldChange change = _changesHistory[_current];
                --_current;
                return change;
            }
            else
                throw new System.InvalidOperationException("Previous move not exist");
        }

        public bool IsExistNextMove() => _current < _end - 1 && !_empty;

        public FieldChange GetNextMove()
        {
            if (_current < _end)
            {
                ++_current;
                FieldChange change = _changesHistory[_current];
                return change;
            }
            else
                throw new System.InvalidOperationException("Next move not exist");
        }

        public void AddMove(GameCoordinate from, GameCoordinate to)
        {
            AddMove(new FieldChange(from, to));
        }
        public void AddMove(FieldChange change)
        {
            if (_empty || _current == _end - 1)
                _changesHistory.Add(change);
            else
            {
                if (_current == -1)
                    _changesHistory.Clear();
                else
                    _changesHistory.RemoveRange(_current + 1, _changesHistory.Count - (_current + 1));

                _changesHistory.Add(change);
            }

            if (_empty)
                _empty = false;
            _end = _changesHistory.Count;
            _current = _end - 1;
        }
        public void Clear()
        {
            _changesHistory.Clear();
            _end = _changesHistory.Count;
            _current = _end;
            _empty = true;
        }
    }
}
