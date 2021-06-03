namespace SharedValueObject.UserAccounting
{
    public class PositionActivity
    {
        public bool Viewing { get; set; }
        public bool Hearing { get; set; }
        public bool Thinking { get; set; }
        public bool Tasting { get; set; }
        public bool Smelling { get; set; }
        public string Other { get; set; }

        public PositionActivity(bool viewing, bool hearing, bool thinking, bool tasting, bool smelling, string other)
        {
            Viewing = viewing;
            Hearing = hearing;
            Thinking = thinking;
            Tasting = tasting;
            Smelling = smelling;
            Other = other;
        }

        //Navigation Properties
        public int PositionId { get; set; }
    }
}
