using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.MapCreator
{
    class MapLoader
    {
        private String mapName;
        public MapLoader(String mapName)
        {
            this.mapName = mapName;
        }
        public String MapLoad()
        {
            String mapname = "untitled1.tmx";
            if (mapname.Contains(".tmx") || mapname.Contains(".xml"))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
            return mapname;
        }

        public string getMapName()
        {
            return mapName;
        }
        public void setMapName(string mapName)
        {
            this.mapName = mapName;
        }
    }
}
