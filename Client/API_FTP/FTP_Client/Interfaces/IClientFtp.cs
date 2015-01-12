using API_FTP.FTP_Client.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_FTP.FTP_Client.Interfaces
{
    interface IClientFtp
    {
        bool Connect();
        bool Disconnect();
        bool Download();
        bool Upload();
        List<ElementFolder> ListFolder();
        List<ElementFile> ListFileFolder();
        void DefinePathRoot();
        int FollowProgress();
        ElementFolder GetPathRootFolder();
        string GetPathRootString();
    }
}
