using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Linq;


namespace UntitledCarGame.MapCreator
{
	class TileMap
	{

		//Map loads in
		//Verify tmx or xml being loaded in
		//Map load string variable
		public string mapDirectory;

		XElement map;

		public TileMap(string mapFile)
		{
			map = XElement.Load(mapFile);
			mapDirectory = Path.GetDirectoryName(mapFile);
		}

		public int mapWidth()
		{
			//Map width information
			int mapWidth = (int)map.Attribute("width");
			int mapTileWidth = (int)map.Attribute("tilewidth");

			mapWidth *= mapTileWidth;
			return mapWidth;
		}

		public int mapHeight()
		{
			//Map height information

			int mapHeight = (int)map.Attribute("height");
			int mapTileHeight = (int)map.Attribute("tileheight");

			mapHeight *= mapTileHeight;
			return mapHeight;

		}


		public List<Gid> gidList()
		{

			List<Gid> gidList = new List<Gid>();
			//Gets GID information
			var tileSets = from tileset in map.Descendants("tileset")
						   select new
						   {
							   tilesetFirstgid = tileset.Attribute("firstgid"),
							   tilesetName = tileset.Attribute("name"),
							   tilesetWidth = tileset.Attribute("tilewidth"),
							   tilesetHeight = tileset.Attribute("tileheight"),
							   tilesetTilecount = tileset.Attribute("tilecount"),
							   tilesetColumns = tileset.Attribute("columns")
						   };

			//Adds gidinfo into the gid object list
			foreach (var tileset in tileSets)
			{
				gidList.Add(new Gid((int)tileset.tilesetFirstgid, (string)tileset.tilesetName, (int)tileset.tilesetWidth, (int)tileset.tilesetHeight, (int)tileset.tilesetTilecount, (int)tileset.tilesetColumns));
			}
			return gidList;
		}


		//Layer class
		public List<Layer> layerList()
		{

			List<Layer> layerList = new List<Layer>();

			//Gets layer information. Layer name width and height
			var tileLayer = from layer in map.Descendants("layer")
							select new
							{
								//layerID = layer.Attribute("id"),
								layerName = layer.Attribute("name"),
								layerWidth = layer.Attribute("width"),
								layerHeight = layer.Attribute("height"),
							};

			foreach (var layer in tileLayer)
			{
				layerList.Add(new Layer((string)layer.layerName, (int)layer.layerWidth, (int)layer.layerHeight));
			}

			return layerList;
		}




		//CVS data class
		public List<LayerStruct> cvsList()
		{

			List<LayerStruct> layers = new List<LayerStruct>();


			//Gets layer information. Layer name width and height
			var tileLayer = from layer in map.Descendants("layer")
							select new
							{
								layerWidth = layer.Attribute("width"),
								layerHeight = layer.Attribute("height"),
							};

			//Gets CVS data
			var layerData = from layer in map.Descendants("layer")
							from data in layer.Descendants("data")
							select new
							{
								grid = data.Value
							};


			foreach (var layer in tileLayer)
			{
				layers.Add(new LayerStruct((int)layer.layerWidth, (int)layer.layerHeight));
			}



			for (int index = 0; index < layerData.Count(); index++)
			{
				string gridString = layerData.ElementAt(index).grid;
				int gridElement = 0;

				for (int j = 0; j < layers[index].height; j++)
				{
					for (int i = 0; i < layers[index].width; i++)
					{
						gridElement++;

						while (gridString[gridElement].CompareTo(',') == 0 || gridString[gridElement].CompareTo('\n') == 0)
						{
							gridElement++;
						}

						layers[index].layerData[i, j] = (int)Char.GetNumericValue(gridString[gridElement]);
					}
				}

			}
			return layers;
		}



		//Image list class
		public List<Images> imagesList()
		{
			List<Images> imageList = new List<Images>();

			var images = from tileset in map.Descendants("tileset")
						 from image in tileset.Descendants("image")
						 select new
						 {
							 imagesource = image.Attribute("source"),
							 imagewidth = image.Attribute("width"),
							 imageheight = image.Attribute("height")
						 };

			foreach (var image in images)
			{

				imageList.Add(new Images((int)image.imagewidth, (int)image.imageheight, (string)image.imagesource));

			}

			return imageList;
		}

		public List<Collision> objectList()
		{
			List<Collision> objList = new List<Collision>();
			//Get object data
			var objectData = from objectgroup in map.Descendants("objectgroup")
							 from Object in objectgroup.Descendants("object")
							 select new
							 {
								 objId = Object.Attribute("id"),
								 objXvalue = Object.Attribute("x"),
								 objYvalue = Object.Attribute("y"),
								 objHeight = Object.Attribute("height"),
								 objWidth = Object.Attribute("width")
							 };
			foreach (var objectdata in objectData)
			{
				if (objectdata.objWidth == null || objectdata.objHeight == null)
				{
					objList.Add(new Collision((int)objectdata.objId, (double)objectdata.objXvalue, (double)objectdata.objYvalue, 20.0, 20.0));
				}
				else
				{
					objList.Add(new Collision((int)objectdata.objId, (double)objectdata.objXvalue, (double)objectdata.objYvalue, (double)objectdata.objWidth, (double)objectdata.objHeight));
				}

			}
			return objList;

		}

	}
}