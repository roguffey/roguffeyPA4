namespace api
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString(){
            string server = "eanl4i1omny740jw.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "jdldpq9okevz3yh1";
            string port = "3306";
            string userName = "v9sslex9a3gzigvi";
            string password = "j9tecm1thlee0a1f";

            cs = $@"server = {server}; user = {userName}; database = {database}; port = {port}; password = {password}";
        }
    }
}