using Selenium.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Selenium.Tests
{
    public class BaseTest : PageObjectsFactory
    {
        [SetUp]
        public void Setup()
        {
            Init();
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
    }
}
