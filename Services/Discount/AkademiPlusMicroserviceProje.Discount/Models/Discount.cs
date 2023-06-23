using System;

namespace AkademiPlusMicroserviceProje.Discount.Models
{
    [Dapper.Contrib.Extensions.Table("Discount")]
    public class Discount
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int Rate { get; set; }
        public string Code { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
