using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab5;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Graph1IsReachable()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph1.txt");

            Assert.IsTrue(undirectedGraph.IsReachable("a", "c"));
            Assert.IsTrue(undirectedGraph.IsReachable("e", "c"));
            Assert.IsTrue(undirectedGraph.IsReachable("d", "e"));
            Assert.IsTrue(undirectedGraph.IsReachable("d", "c"));
        }

        [TestMethod]
        public void Graph1ConnectedComponents()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph1.txt");

            Assert.AreEqual(1, undirectedGraph.ConnectedComponents);
        }


        [TestMethod]
        public void Graph2IsReachable()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph2.txt");

            Assert.IsFalse(undirectedGraph.IsReachable("a", "c"));
            Assert.IsFalse(undirectedGraph.IsReachable("e", "c"));
            Assert.IsFalse(undirectedGraph.IsReachable("d", "e"));
            Assert.IsFalse(undirectedGraph.IsReachable("b", "a"));
            Assert.IsFalse(undirectedGraph.IsReachable("d", "b"));

        }

        [TestMethod]
        public void Graph2ConnectedComponents()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph2.txt");

            Assert.AreEqual(5, undirectedGraph.ConnectedComponents);
        }


        [TestMethod]
        public void Graph3IsReachable()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph3.txt");

            Assert.IsTrue(undirectedGraph.IsReachable("a", "c"));
            Assert.IsTrue(undirectedGraph.IsReachable("e", "d"));
            Assert.IsTrue(undirectedGraph.IsReachable("h", "g"));

            Assert.IsFalse(undirectedGraph.IsReachable("a", "h"));
            Assert.IsFalse(undirectedGraph.IsReachable("c", "i"));
            Assert.IsFalse(undirectedGraph.IsReachable("g", "b"));

        }

        [TestMethod]
        public void Graph3ConnectedComponents()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph3.txt");

            Assert.AreEqual(3, undirectedGraph.ConnectedComponents);
        }

        [TestMethod]
        public void Graph4IsReachable()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph4.txt");

            Assert.IsTrue(undirectedGraph.IsReachable("a", "c"));
            Assert.IsTrue(undirectedGraph.IsReachable("e", "i"));
            Assert.IsTrue(undirectedGraph.IsReachable("g", "b"));
            Assert.IsTrue(undirectedGraph.IsReachable("c", "f"));
            Assert.IsTrue(undirectedGraph.IsReachable("a", "d"));
            Assert.IsTrue(undirectedGraph.IsReachable("b", "i"));

        }

        [TestMethod]
        public void Graph4ConnectedComponents()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/graph4.txt");

            Assert.AreEqual(1, undirectedGraph.ConnectedComponents);
        }

        [TestMethod]
        public void SavannahIsReachable()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/Savannah.txt");

            Assert.IsTrue(undirectedGraph.IsReachable("a", "c"));
            Assert.IsTrue(undirectedGraph.IsReachable("e", "i"));
            Assert.IsTrue(undirectedGraph.IsReachable("g", "b"));
            Assert.IsTrue(undirectedGraph.IsReachable("c", "f"));
            Assert.IsTrue(undirectedGraph.IsReachable("a", "j"));
            Assert.IsTrue(undirectedGraph.IsReachable("b", "i"));


            Assert.IsFalse(undirectedGraph.IsReachable("a", "d"));
            Assert.IsFalse(undirectedGraph.IsReachable("d", "j"));

        }

        [TestMethod]
        public void SavannahConnectedComponents()
        {
            UndirectedGraph undirectedGraph = new UndirectedGraph("../../../graphs/Savannah.txt");

            Assert.AreEqual(2, undirectedGraph.ConnectedComponents);
        }
    }
}
