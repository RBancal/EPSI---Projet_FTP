using API_FTP.FTP_Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Classes
{
    public abstract class Element : ITransfer
    {
        protected string _name, _path;

        protected string Name { get { return _name; } set { _name = value; } }
        protected string Path { get { return _path; } set { _path = value; } }

        public virtual string GetPath()
        {
            return Path;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual long GetSize()
        {
            return -1;
        }

        public virtual bool EstUnDossier()
        {
            return false;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
