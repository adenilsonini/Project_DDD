using Flunt.Notifications;
using System;

namespace JSP.Domain.Entities
{
    public abstract class BaseEntity: Notifiable
    {
        protected BaseEntity(int id, bool ativo = true)
        {
            Id = id;
            Ativo = ativo;
            datacad = DateTime.Now;
        }

        public virtual int Id { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime datacad { get; private set; }
    }
}