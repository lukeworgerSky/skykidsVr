using System;

namespace AssemblyCSharp
{
	public class Product
	{
		public int id { get; set; }
		public double price { get; set; }
		public string name { get; set;}

		public Product (int id, double price, string name)
		{
			this.id = id;
			this.price = price;
			this.name = name;
		}
	}
}

