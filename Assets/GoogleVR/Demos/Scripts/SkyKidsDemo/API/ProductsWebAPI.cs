using System;
using System.Collections;
using System.Collections.Generic;


namespace AssemblyCSharp
{
	public class ProductsWebAPI : IProductsWebAPI
	{
		//using System.Net.HttpWebRequest;
		public ProductsWebAPI()
		{
		}

		public List<Product> getProducts(){
			return new List<Product> ();
		}
	}
}

