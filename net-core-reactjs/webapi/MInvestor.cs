namespace webapi
{
    public class MInvestor
    {
        public int FirmId { get; set; }
        public string? FirmName { get; set; }
        public string? FirmType { get; set; }
        public DateTime DateAdded { get; set; }
        public string? Address { get; set; }

        public MInvestor()
        {
            FirmId = 0;
            FirmName = string.Empty;
            FirmType = string.Empty;
            DateAdded = DateTime.MinValue;
            Address = string.Empty;
        }
        public MInvestor(int _nFirmId, string _strFirmName, string _strType, DateTime _dteAdded, string _strAddress)
        {
            FirmId = _nFirmId;
            FirmName = _strFirmName;
            FirmType = _strType;
            DateAdded = _dteAdded;
            Address = _strAddress;
        }
    }
}
