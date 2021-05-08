using System;

namespace Curso.Api.CrossCutting.Command
{
    public class UserEntityCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
