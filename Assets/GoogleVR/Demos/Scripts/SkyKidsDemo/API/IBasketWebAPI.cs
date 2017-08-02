using System;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public interface IBasketWebAPI
	{
		void sendOrder(Dictionary<int,int> productsToBuy);
	}
}

