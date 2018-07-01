using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnrealMapMixer.MyMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealMapMixer.MyMath.Tests
{
    [TestClass()]
    public class Scale3DTests
    {
        [TestMethod()]
        public void FromPropertyTest()
        {
            string text = "(SheerAxis=SHEER_ZX)";
            var scale = Scale3D.FromProperty(text);
            Assert.AreEqual(1.0, scale.X);
            Assert.AreEqual(1.0, scale.Y);
            Assert.AreEqual(1.0, scale.Z);
            Assert.AreEqual(SheerAxis.ZX, scale.SheerAxis);
            Assert.AreEqual(0.0, scale.SheerRate);

            text = "(Scale=(Y=2.0,Z=3.0),SheerAxis=SHEER_XY,SheerRate=0.5)";
            scale = Scale3D.FromProperty(text);
            Assert.AreEqual(1.0, scale.X);
            Assert.AreEqual(2.0, scale.Y);
            Assert.AreEqual(3.0, scale.Z);
            Assert.AreEqual(SheerAxis.XY, scale.SheerAxis);
            Assert.AreEqual(0.5, scale.SheerRate);
        }
    }
}