using System;

namespace RockPaperScissorsLizardSpock
{
    public abstract class SelectionBase : IComparable<SelectionBase>
    {
        public abstract int CompareTo(SelectionBase other);
        public string Name { get { return GetType().Name; } }
        public abstract string GetWinningVerb(SelectionBase other);
    }
}
