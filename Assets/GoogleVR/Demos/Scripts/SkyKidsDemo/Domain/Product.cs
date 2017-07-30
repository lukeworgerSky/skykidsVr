using System;

namespace AssemblyCSharp
{
	public class Product
	{
		public int id { get; set; }
		public double price { get; set; }

		public Product (int id, double price)
		{
			this.id = id;
			this.price = price;
		}
	}
}

