using System;

namespace JsonReporter.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid(); // Gera um ID único automaticamente ao criar a entidade
        }
    }
}