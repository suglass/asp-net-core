namespace webapi
{
    [Serializable]
    public class MAuth
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }

        public MAuth() 
        {
            access_token = string.Empty;
            expires_in = 0;
            token_type = string.Empty;
            refresh_token = string.Empty;
            scope = string.Empty;
        }
        public MAuth(string access_token, int expires_in, string token_type, string refresh_token, string scope)
        {
            this.access_token = access_token;
            this.expires_in = expires_in;
            this.token_type = token_type;
            this.refresh_token = refresh_token;
            this.scope = scope;
        }
    }
}
