using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingLibrary;
public class DLC
{
    public DLC(int gameID, int dlcID, string title)
    {
        GameId = gameID;
        DlcID = dlcID;
        Title = title;
    }
    public int GameId { get; set; }
    public int DlcID { get; set; }
    public string Title { get; set; }
}
