using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogged.Model
{
    [Table("Channel")]
    public class Channel
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Url { get; set; }
    }
}
