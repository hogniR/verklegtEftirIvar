using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using verklegtVerkefni.Models;

namespace verklegtVerkefni.RepoClasses
{
    public class filesRepository
    {
        DataContext m_db = new DataContext();
        public void addNewFile(files newFile)
        {
            m_db.files.Add(newFile);
            save();
            return;
        }
        public files getFileById(int id)
        {
            var result = (from s in m_db.files
                          where s.id == id
                          select s).SingleOrDefault();

            return result;
        }
        public void save()
        {
            m_db.SaveChanges();
            return;
        }
    }
}