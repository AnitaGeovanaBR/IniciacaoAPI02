using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Commands
{
    public class RestaurarBibliotecaCommand
    {
        public required Guid IdBiblioteca { get; set; }
    }
}
