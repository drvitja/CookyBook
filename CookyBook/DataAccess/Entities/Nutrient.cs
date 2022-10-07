
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class nutrient : EntityBase
    {
        public string? Title { get; set; }

        internal void Add(nutrient nutrient)
        {
            throw new NotImplementedException();
        }
    }
}