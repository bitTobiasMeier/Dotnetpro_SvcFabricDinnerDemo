using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace SvcFabricDinnerDemo.DinnerMenuService.Interfaces
{
    public class Dish
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

   
   
}




