using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogged.Model
{
    [Table("Episodes")]
    public class Episode
    {
        [ExplicitKey]
        public int Id { get; set; } 
        public int Channel { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
