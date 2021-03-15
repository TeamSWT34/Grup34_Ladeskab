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

        [TestCase(true, false, false)]
        [TestCase(false, true, false)]
        [TestCase(true, true, false)]
		[TestCase(false, false, true)]
		public void LockDoor_isLocked(bool a,bool b, bool res)
        {
			if(a)
				_uut.OnDoorOpen();
			
            _uut.LockDoor();

			if(b)
				_uut.UnlockDoor();

			Assert.That(_uut.IsLocked==res);
        }

        [TestCase(true, true, false)]
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
		[TestCase(false, false, false)]
		public void LockDoor_isUnlocked(bool a, bool b, bool res)
        {
            if (a)
                _uut.OnDoorOpen();
            
            if (b)
				_uut.LockDoor();

			_uut.UnlockDoor();

			Assert.That(_uut.IsLocked == res);
        }
	}
}