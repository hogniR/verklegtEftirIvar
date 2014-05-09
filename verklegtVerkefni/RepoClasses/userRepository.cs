using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verklegtVerkefni.Models;

namespace verklegtVerkefni.RepoClasses
{
    public class userRepository
    {
        DataContext m_db = new DataContext();

        public void addNewUser(users newUser)
        {
            m_db.users.Add(newUser);
            save();
            return;
        }
        public users getUserByName(string name)
        {
            var result = (from s in m_db.users
                          where s.userName == name
                          select s).SingleOrDefault();
            return result;
        }
        public users getUserById(int id)
        {
            var result = (from s in m_db.users
                          where s.id == id
                          select s).SingleOrDefault();

            return result;
        }
        public IEnumerable<users> getAllUsers()
        {
            return m_db.users;
        }
        public void save()
        {
            m_db.SaveChanges();
            return;
        }
    }
}