
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

            Assert.AreEqual(97, validPlayer1.No);
            Assert.AreEqual("Connor McDavid", validPlayer1.Playername);
            Assert.AreEqual(Position.C, validPlayer1.Position);

        }
        [TestMethod]
        [DataRow(-1)]
        [DataRow(99)]
    public void No_InvalidNo_ThrowsArgumentOutOfRangeException(int no)
        {
            Roster invalidPLayer1 = new Roster(no, "Conner McDavid", Position.C);

            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Roster invalidPLayer1 = new Roster(no, "Conner McDavid", Position.C);
            });
            Assert.AreEqual("Player number must be between 1 and 98", exception.ParamName);
        }

    }
}