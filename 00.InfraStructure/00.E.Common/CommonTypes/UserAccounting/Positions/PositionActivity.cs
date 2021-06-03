namespace CommonTypes.UserAccounting.Positions
{
    public class PositionActivity
    {
        public bool Viewing { get; private set; }
        public bool Hearing { get; private set; }
        public bool Thinking { get; private set; }
        public bool Tasting { get; private set; }
        public bool Smelling { get; private set; }
        public string Other { get; private set; }
        
        public PositionActivity(bool viewing, bool hearing, bool thinking, bool tasting, bool smelling, string other)
        {
            Viewing = viewing;
            Hearing = hearing;
            Thinking = thinking;
            Tasting = tasting;
            Smelling = smelling;
            Other = other;
        }
    }
}