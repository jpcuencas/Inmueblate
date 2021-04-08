using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NuevoInmueblateGenNHibernate.CAD.RedSocial;

namespace NuevoInmueblateCP
{
    public class BasicCP
    {
        protected ISession session;

        protected bool sessionStarted;
        protected bool transaccionStarted;

        protected ITransaction tx;

        protected BasicCP()
        {
            session = null; tx = null;
            sessionStarted = true;
            transaccionStarted = false;

        }

        protected BasicCP(ISession sessionAux)
        {
            session = sessionAux;
            sessionStarted = false;
            transaccionStarted = false;
        }

        protected void SessionInitializeWithoutTransaction()
        {
            if (session == null && sessionStarted == true)
            {
                session = NHibernateHelper.OpenSession();
            }
        }

        protected void SessionInitializeTransaction()
        {
            if (session == null && tx == null && sessionStarted == true && transaccionStarted == false)
            {
                session = NHibernateHelper.OpenSession();
                tx = session.BeginTransaction();
                transaccionStarted = true;
            }
        }

        protected void SessionCommit()
        {
            if (transaccionStarted && tx != null && session.IsOpen)
            {
                tx.Commit();
                transaccionStarted = false;
            }
        }
        protected void SessionRollBack()
        {
            if (transaccionStarted && tx != null && session.IsOpen)
            {
                tx.Rollback();
                transaccionStarted = false;
            }
        }

        protected void SessionClose()
        {
            if (sessionStarted && session != null && session.IsOpen)
            {
                session.Close();
                session.Dispose();
                session = null;
                tx = null;
            }
        }
    }
}
