using System;

namespace AssemblyCSharp
{
	public class Product
	{
		int id { get; set; }
		double price { get; set; }

		public Product (int id, double price)
		{
			this.id = id;
			this.price = price;
		}
	}
}

