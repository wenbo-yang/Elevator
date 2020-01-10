using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorTests
{


    [TestClass]
    public class ElevatorControllerUnitTests
    {
        [TestMethod]
        public void GivenOneEmptyElevatorAndRequest_GetBestElevator_ShouldReturnCorrectIndex()
        {
            var elevators = new Elevator[] { new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = new ElevatorController().GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 0);
        }

        [TestMethod]
        public void GivenTwoEmptyElevatorsAtTheSamePositionAndRequest_GetBestElevator_ShouldReturnFirstIndex()
        {
            var elevators = new Elevator[] { new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 }, new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = new ElevatorController().GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 0);
        }

        [TestMethod]
        public void GivenTwoElevatorsWithTheSecondCloserToUser_GetBestElevator_ShouldReturnSecondIndex()
        {
            var elevators = new Elevator[] { new Elevator { Position = 0, Stops = new Queue<int>(), Time = 0 }, new Elevator { Position = 5, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = new ElevatorController().GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 1);
        }

        [TestMethod]
        public void GivenTwoElevatorsWithOneCloserToUserButHaveQueuesLonger_GetBestElevator_ShouldReturnSecondIndex()
        {
            var elevator1Queue = new Queue<int>();
            elevator1Queue.Enqueue(0);
            var elevators = new Elevator[] { new Elevator { Position = 10, Stops = elevator1Queue, Time = 0 }, new Elevator { Position = 5, Stops = new Queue<int>(), Time = 0 } };

            var elevatorIndex = new ElevatorController().GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 1);
        }

        [TestMethod]
        public void GivenThreeElevatorsDifferentQueues_GetBestElevator_ShouldReturnTheCorrectIndexIndex()
        {
            var elevator1Queue = new Queue<int>();
            elevator1Queue.Enqueue(0); elevator1Queue.Enqueue(2); elevator1Queue.Enqueue(12);
            var elevator2Queue = new Queue<int>();
            elevator2Queue.Enqueue(10); elevator2Queue.Enqueue(0); elevator2Queue.Enqueue(5);
            var elevator3Queue = new Queue<int>();
            elevator3Queue.Enqueue(12); elevator3Queue.Enqueue(14);
            var elevators = new Elevator[] { new Elevator { Position = 10, Stops = elevator1Queue }, new Elevator { Position = 5, Stops = elevator2Queue }, new Elevator { Position = 11, Stops = elevator3Queue } };

            var elevatorIndex = new ElevatorController().GetBestElevator(elevators, 10, 12);

            Assert.IsTrue(elevatorIndex == 2);
        }
    }
}
