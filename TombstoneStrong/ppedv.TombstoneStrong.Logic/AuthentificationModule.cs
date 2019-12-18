using ppedv.TombstoneStrong.Domain;
using ppedv.TombstoneStrong.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace ppedv.TombstoneStrong.Logic
{
    public class AuthentificationModule<T> : CoreModul<T> where T : Entity
    {
        public AuthentificationModule(User currentUser, ICoreModul<T> parent ,IUnitOfWork UoW) : base(UoW)
        {
            this.parent = parent;
            this.currentUser = currentUser;
        }
        private readonly User currentUser;
        private readonly ICoreModul<T> parent;

        public override void Add(T item)
        {
            if (currentUser.HasFlag(User.CanWrite))
                parent.Add(item);
            else
                throw new InvalidOperationException($"Der aktuelle User darf den Add-Befehl nicht ausführen !");
        }

        public override void Delete(T item)
        {
            if (currentUser.HasFlag(User.CanDelete))
                parent.Delete(item);
            else
                throw new InvalidOperationException($"Der aktuelle User darf den Delete-Befehl nicht ausführen !");
        }

        public override IEnumerable<T> GetAll()
        {
            if (currentUser.HasFlag(User.CanRead))
                return parent.GetAll();
            else
                throw new InvalidOperationException($"Der aktuelle User darf den GetAll-Befehl nicht ausführen !");
        }

        public override T GetByID(int ID)
        {
            if (currentUser.HasFlag(User.CanRead))
                return parent.GetByID(ID);
            else
                throw new InvalidOperationException($"Der aktuelle User darf den GetByID-Befehl nicht ausführen !");
        }

        public override void Update(T item)
        {
            if (currentUser.HasFlag(User.CanWrite))
                parent.Update(item);
            else
                throw new InvalidOperationException($"Der aktuelle User darf den Update-Befehl nicht ausführen !");
        }
    }

    public class ExceptionModule<T> : CoreModul<T> where T : Entity
    {
        public ExceptionModule(ICoreModul<T> parent, IUnitOfWork UoW, Action<string> callback) : base(UoW)
        {
            this.parent = parent;
            this.callback = callback;
        }
        private readonly Action<string> callback;
        private readonly ICoreModul<T> parent;

        public override void Add(T item)
        {
            try
            {
                parent.Add(item);
            }
            catch (Exception ex)
            {
                callback(ex.Message);
            }
        }

        public override void Delete(T item)
        {
            try
            {
                parent.Delete(item);
            }
            catch (Exception ex)
            {
                callback(ex.Message);
            }
        }

        public override IEnumerable<T> GetAll()
        {
            try
            {
                return parent.GetAll();
            }
            catch (Exception ex)
            {
                callback(ex.Message);
                return default;
            }
        }

        public override T GetByID(int ID)
        {
            try
            {
                return parent.GetByID(ID);
            }
            catch (Exception ex)
            {
                callback(ex.Message);
                return default;
            }
        }

        public override void Update(T item)
        {
            try
            {
                parent.Update(item);
            }
            catch (Exception ex)
            {
                callback(ex.Message);
            }
        }
    }
}
