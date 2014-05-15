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
        // þetta fall er oft kallað í í requestcontroller og tekur það við færibreytu
        // sem fallið vistar svo í gagnagrunni
        public void addNewRequest(Requests newRequest)
        {
            m_db.requests.Add(newRequest);
            m_db.SaveChanges();
            return;
        }
        // þetta fall skilar einni beiðni með tilteknu ID-i
        public void save()
        {
            m_db.SaveChanges();
            return;
        }
        // skilar öllum beiðnum í gagnagrunni sem IEnumerable
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