namespace webapi
{
    [Serializable]
    public class MMeta
    {
        public int total { get; set; }
        public int returned { get; set; }
        public int page { get; set; }

        public MMeta()
        {
            total = 0;
            returned = 0;
            page = 0;
        }  
        public MMeta(int total, int returned)
        {
            this.total = total;
            this.returned = returned;
        }
    }
}
