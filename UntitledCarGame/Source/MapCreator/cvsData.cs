using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledCarGame.MapCreator
{
	struct LayerStruct
        {
            public int width;
            public int height;
            public int[,] layerData;

            public LayerStruct(int _width, int _height)
            {
                width = _width;
                height = _height;

                layerData = new int[_width, _height];
            }
        }
    }

