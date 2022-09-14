
using OOPReview;

namespace TestNhlSystem
{
    [TestClass]
    public class RosterTest

    {
        [TestMethod]
        [DataRow(97, "Connor McDavid", Position.C)]
        [DataRow(18, "Zach Hyman", Position.LW)]
        [DataRow(25, "Darnell Nurse", Position.D)]


        public void Constructor_ValidValues_SetsNoNamePosition(int no, string playerName, Position position)
        {
            Roster validPlayer1 = new Roster(no, playerName, position);

            Assert.AreEqual(no, validPlayer1.No);
            Assert.AreEqual(playerName, validPlayer1.Playername);
            Assert.AreEqual(position, validPlayer1.Position);

        }
        [TestMethod]
        [DataRow(-1)]
        [DataRow(99)]
    public void No_InvalidNo_ThrowsArgumentOutOfRangeException(int no)
        {
            
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Roster invalidPLayer1 = new Roster(no, "Conner McDavid", Position.C);
            });
            Assert.AreEqual("Games played must be within 0-98", exception.ParamName);
        }

    }
}