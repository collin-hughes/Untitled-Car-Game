using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.MapCreator
{
    class Layer
    {
        private string layerName;
        private int layerWidth;
        private int layerHeight;

        public Layer(string layerName, int layerWidth, int layerHeight)
        {
           
            this.layerName = layerName;
            this.layerWidth = layerWidth;
            this.layerHeight = layerHeight;
        }

        public string getName()
        {
            return layerName; 
        }

        public int getWidth()
        {
            return layerWidth; 
        }

        public int getHeight()
        {
            return layerHeight; 
        }


        public void setName(string name)
        {
            layerName = name; 
        }

        public void setWidth(int width)
        {
            layerWidth = width;
        }

        public void setHeight(int height)
        {
            layerHeight = height; 
        }

        public string getDataLayer()
        {
            return this.layerName + " " + this.layerWidth + " " + this.layerHeight; 
        }
    }
}
