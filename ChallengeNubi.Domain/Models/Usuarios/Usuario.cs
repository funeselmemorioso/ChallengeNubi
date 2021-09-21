using System;
using System.Collections.Generic;
using System.Text;

namespace ChallengeNubi.Domain.Models.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String EMail { get; set; }
        public String Password { get; set; }       
    }
}
