using PocoGenerator.Domain.Models.Enums;

namespace PocoGenerator.Domain.Models   
{
    public class ConnectionStringProperties
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool IntegratedSecurity { get; set; }  
        
        public AuthenticationTypes AuthenticationType { get; set; }
    }
}
