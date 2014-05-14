using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using verklegtVerkefni.Models;
using System.Data.SqlClient;

namespace verklegtVerkefni.RepoClasses
{
    public class requestsRepository
    {
        DataContext m_db = new DataContext();
        public void addNewRequest(Requests newRequest)
        {
            m_db.requests.Add(newRequest);
            m_db.SaveChanges();
            return;
        }
        public void save()
        {
            m_db.SaveChanges();
            return;
        }
        public Requests getRequestById(int id)
        {
            var result = (from s in m_db.requests
                          where s.id == id
                          select s).SingleOrDefault();

            return result;
        }
        public IEnumerable<Requests> getAllRequests()
        {
            return m_db.requests;
        }
    }
}