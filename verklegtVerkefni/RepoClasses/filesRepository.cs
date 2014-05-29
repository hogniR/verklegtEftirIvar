using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using verklegtVerkefni.Models;

namespace verklegtVerkefni.RepoClasses
{
    public class filesRepository
    {
        DataContext m_db = new DataContext();
        // þetta fall er oft kallað í í filecontroller og tekur það við færibreytu
        // sem fallið vistar svo í gagnagrunni
        public void addNewFile(files newFile)
        {
            m_db.files.Add(newFile);
            m_db.SaveChanges();
            return;
        }
        // þetta fall skilar einni skrá með tilteknu ID-i
        public files getFileById(int id)
        {
            var result = (from s in m_db.files
                          where s.id == id
                          select s).SingleOrDefault();

            return result;
        }
        // skilar öllum skrám í gagnagrunni sem IEnumerable
        public IEnumerable<files> getAllFiles()
        {
            return m_db.files;
        }
        public void updateFile(files fileToUpdate)
        {
            m_db.SaveChanges();
        }
        public void save()
        {
            m_db.SaveChanges();
        }
    }
}