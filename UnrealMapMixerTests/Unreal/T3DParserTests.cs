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
    public class T3DParserTests
    {
        [TestMethod()]
        public void MoveVertexTest()
        {
            string textFrom = @"             Vertex   +00000.000000,+00256.000000,-00016.000000
             Vertex   +00064.000000,+00000.000000,-00016.000000
";
            string textTo = @"             Vertex   +00032.000000,+00128.000000,-00032.000000
             Vertex   +00064.000000,+00000.000000,-00016.000000
";
            var vertexFrom = new Point3D(0.0, 256.0, -16.0);
            var vertexTo = new Point3D(32.0, 128.0, -32.0);

            string actual = T3DParser.MoveVertex(textFrom, vertexFrom, vertexTo, 1e-3);
            Assert.AreEqual(textTo, actual);
        }
    }
}