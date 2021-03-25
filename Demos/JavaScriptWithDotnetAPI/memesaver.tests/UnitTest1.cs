using System;
using BusinessLogic;
using Xunit;

namespace memesaver.tests
{
	public class UnitTest1
	{
		[Fact]
		public void QuadrupleTheIntReturnsQuadrupleTheInt()
		{
			// arrange
			var businessClass = new UserMethods();
			int x = 4;

			// act
			int result = businessClass.QuadrupleTheInt(x);

			// assert
			Assert.Equal(4 * 4, result);
		}
	}


}
