using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.MapCreator
{
   public class Collision
    {
      private int id;
      private double Xvalue;
      private double Yvalue;
        private double height = 20.0;
        private double width = 20.0;

        public Collision(int id, double Xvalue, double Yvalue, double width, double height)
        {
            this.id = id;
            this.Xvalue = Xvalue;
            this.Yvalue = Yvalue;
            this.height = height;
            this.width = width;

        }

        public int objId()
    {
        return id;
    }
    public double objXvalue()
    {
        return Xvalue;
    }
    public double objYvalue()
    {
        return Yvalue;
    }
    public double objHeight()
    {
        return height;
    }
    public double objWidth()
    {
        return width;
    }
    public void setobjId(int id)
    {
        this.id = id;
    }
    public void setXvalue(double Xvalue)
    {
        this.Xvalue = Xvalue;
    }
    public void setYvalue(double Yvalue)
    {
        this.Yvalue = Yvalue;
    }
    public void setHeight(double height)
    {
        this.height = height;
    }
    public void setWidth(double width)
    {
        this.width = width;
    }
    public string getData()
    {
        return this.id + " " + this.Xvalue + " " + this.Yvalue + " " + this.height + " " + this.width;
    }

}

}


