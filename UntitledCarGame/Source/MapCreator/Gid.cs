using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace UntitledCarGame.MapCreator
{
   public class Gid
    {
        
      
        private int firstgid  ;
        private string tilesetname ;
        private int tilesetWidth;
        private int tilesetHeight;
        private int tilesetColumn;
        private int tilesetCount; 

        public Gid(int firstgid, string tilesetname, int tilesetWidth, int tilesetHeight, int tilesetCount, int tilesetColumn)
        {
            this.firstgid = firstgid;
            this.tilesetname = tilesetname;
            this.tilesetWidth = tilesetWidth;
            this.tilesetHeight = tilesetHeight;
            this.tilesetCount = tilesetCount;
            this.tilesetColumn = tilesetColumn; 
        }

        public int getGid()
        {
            return firstgid; 
        }

        public string getTileName()
        {
            return tilesetname; 
        }
        public int getTileWidth()
        {
            return tilesetWidth;
        }
        public int getTileHeight()
        {
            return tilesetHeight; 
        }
        public int getTileCount()
        {
            return tilesetCount; 
        }
        public int getTileColumn()
        {
            return tilesetColumn; 
        }

        public void setName(string name)
        {
            tilesetname = name; 
            
        }
        public void setGid(int gid)
        {
            firstgid = gid; 

        }
        public void setHeight(int tileHeight)
        {
            tilesetHeight = tileHeight; 
        }
        public void setWidth(int tileWidth)
        {
            tilesetWidth = tileWidth; 
        }
        public void setCount(int tileCount)
        {
            tilesetCount = tileCount; 
        }
        public void setColumn(int tileColumn)
        {
            tilesetColumn = tileColumn;
        }

        public string getDataGid()
        {
            return this.firstgid + " " + this.tilesetname + " "  + this.tilesetWidth + " " + this.tilesetHeight + " " + this.tilesetCount + " " + this.tilesetColumn;
        }
    }

}

