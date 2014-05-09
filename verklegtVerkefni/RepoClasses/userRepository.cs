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
        public void save()
        {
            m_db.SaveChanges();
            return;
        }
    }
}