using ChargingCabinetLib.Interface;
using NUnit.Framework;

namespace ChargingCabinetLib.Test.Unit
{
    [TestFixture]
    public class DoorTests
    {
	    private Door _uut;

	    [SetUp]
	    public void Setup()
	    {
		    _uut = new Door();
	    }

	    [Test]
	    public void If_Door_Open()
	    {
		    DoorOpenEventArgs ifDoorOpen = null;
		    _uut.DoorOpenCloseEvent += (o, e) => ifDoorOpen = e;
			_uut.OnDoorOpen();
			Assert.That(ifDoorOpen.DoorOpen);
	    }

	    [TestCase(true, 2, true)]
	    [TestCase(false, 0, false)]
	    public void If_Door_Closed(bool a, int b, bool res)
	    {
		    bool ifDoorClosed = false;
		    int eventCounter = 0;
		    _uut.DoorOpenCloseEvent += (o, e) =>
		    {
			    ifDoorClosed = !e.DoorOpen;
			    eventCounter++;
		    };

		    if (a)
		    {
			    _uut.OnDoorOpen();
		    }
			_uut.OnDoorClose();


			Assert.That(eventCounter == b && ifDoorClosed == res);
	    }
    }
}