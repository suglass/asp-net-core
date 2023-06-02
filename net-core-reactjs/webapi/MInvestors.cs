namespace webapi
{
    [Serializable]
    public class MInvestors
    {
        public MMeta meta { get; set; }
        public List<MInvestor> data = new List<MInvestor>();

        public MInvestors()
        {
            meta = new MMeta();
            data = new List<MInvestor>();
        }
    }
}
