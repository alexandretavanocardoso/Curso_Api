using System;
using System.ComponentModel.DataAnnotations;

namespace Curso.Api.Domain.Entities
{
    // Tabela geral de entitidade - Padrão para todas tabelas
    public abstract class BaseEntity
    {
        private DateTime? _createAt;

        [Key]
        public Guid Id { get; set; }


        // Retorna o valor para a CreateAt
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; } // Como pode ser Nullo, caso for recebe o Datetime,Now
        }
        
        public DateTime? UpdateAt { get; set; }
    }
}
