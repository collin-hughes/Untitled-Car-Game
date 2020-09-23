using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.MapCreator
{
    public class Images
    {
        private int imageWidth;
        private int imageHeight;
        private string imageSource;

        public Images(int imageWidth, int imageHeight, string imageSource)
        {
            this.imageWidth = imageWidth;
            this.imageHeight = imageHeight;
            this.imageSource = imageSource; 
        }

        public int getimageWidth()
        {
            return imageWidth; 
        }

        public int getimageHeight()
        {
            return imageHeight; 
        }

        public string getimageSource()
        {
            return imageSource; 
        }

        public void setimageWidth(int imageWidth)
        {
            this.imageWidth = imageWidth; 
        }

        public void setimageHeight(int imageHeight)
        {
            this.imageHeight = imageHeight; 
        }

        public void setimageSource(string imageSource)
        {
            this.imageSource = imageSource; 
        }

        public string getDataImage()
        {
            return this.imageWidth + " " + this.imageHeight + " " + this.imageSource;
        }

    } 
}
