using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnrealMapMixer.Unreal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMapMixer.Unreal.Tests
{
    [TestClass()]
    public class T3DFormatterTests
    {
        [TestMethod()]
        public void GetVertexCoordTest()
        {
            Assert.AreEqual("+00000.000000", T3DFormatter.GetVertexCoord(0.0));
            Assert.AreEqual("+00001.100000", T3DFormatter.GetVertexCoord(1.1));
            Assert.AreEqual("-12345.123456", T3DFormatter.GetVertexCoord(-12345.123456));
        }
    }
}