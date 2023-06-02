using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestorsController : Controller
    {
        private readonly ILogger<InvestorsController> _logger;

        public InvestorsController(ILogger<InvestorsController> logger)
        {
            _logger = logger;
        }

        // [HttpGet(Name = "GetInvestors")]
        [Route("")]
        public IEnumerable<MInvestor> Index(int? id)
        {
            List<string> w_lstrFirmIDs = new List<string>();
            w_lstrFirmIDs.Add("2670");
            w_lstrFirmIDs.Add("2792");
            w_lstrFirmIDs.Add("332");
            w_lstrFirmIDs.Add("3611");

            string w_strToken = PreqinApiHelper.getToken("8f0bc69bc2a643f8bb8034a15081962e", "dummydatafeeds@preqin.com");
            MInvestors w_mInvestors = PreqinApiHelper.getInvestors(w_lstrFirmIDs, w_strToken);

            List<MInvestor> w_lstmInvestors = new List<MInvestor>();
            if (w_mInvestors != null)
                w_lstmInvestors.AddRange(w_mInvestors.data);

            return Enumerable.Range(1, w_lstmInvestors.Count).Select(index => w_lstmInvestors[index - 1])
            .ToArray();
        }

        [Route("{id}")]
        public IEnumerable<MInvestor> Detail(int id)
        {
            string w_strToken = PreqinApiHelper.getToken("8f0bc69bc2a643f8bb8034a15081962e", "dummydatafeeds@preqin.com");
            List<string> w_lstrFirmIDs = new List<string>();
            w_lstrFirmIDs.Add(id.ToString());
            MInvestors w_mInvestors = PreqinApiHelper.getInvestors(w_lstrFirmIDs, w_strToken);

            List<MInvestor> w_lstmInvestors = new List<MInvestor>();
            if (w_mInvestors != null)
                w_lstmInvestors.AddRange(w_mInvestors.data);

            return Enumerable.Range(1, w_lstmInvestors.Count).Select(index => w_lstmInvestors[index - 1])
            .ToArray();
        }
    }
}
