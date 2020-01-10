using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorTests
{
    // Idea: simulation
    // In this simulation, I am assuming if an elevator goes to the next floor it takes 1 unit of time.
    // If there is a stop situation it takes 2 units of time
    // The elevator class contains a method Next(), this would run to next time increment. 
    // If it reaches a stop, it will wait, and if it is going it will change position by 1 floor
    // GetBestElevator() would run this simulation
    // it will call Next() for all elevators
    // during the process, it will cache the state for each elevator. 
    // If at a particular time slot it picked up, then the state changes from Going to PickedUp
    // and when we reached the destination from the Pickedup state, we will break out of the loop. 

    // Big O: Time = O(T) where T = numberOfFloors * (elevator speed + elevator open and close door time) * number of elevators (K * F * N)
    //        Space = O(N) where N = number of elevators

    [TestClass]
    public class ElevatorUnitTests
    {
        [TestMethod]
        public void GivenElevatorsWithNoStops_Next_ShouldNotChangePosition()
        {
            var elevator = new Elevator { Position = 0, Stops = new Queue<int>() };

            elevator.Next();

            Assert.IsTrue(elevator.Position == 0);
        }

        [TestMethod]
        public void GivenElevatorsWithNoStops_Next_ShouldNotChangeTime()
        {
            var elevator = new Elevator { Position = 0, Stops = new Queue<int>() };

            elevator.Next();

            Assert.IsTrue(elevator.Time == 0);
        }

        [TestMethod]
        public void GivenElevatorsWithPositionAndStop_Next_ShouldReachFinalStop()
        {
            var elevatorQueue = new Queue<int>();
            elevatorQueue.Enqueue(2);
            var elevator = new Elevator { Position = 0, Stops = elevatorQueue };

            elevator.Next(); elevator.Next();

            Assert.IsTrue(elevator.Position == 2);
        }

        [TestMethod]
        public void GivenElevatorsAndQueuedPositions_Next_ShouldReachWithCorrectTime()
        {
            var elevatorQueue = new Queue<int>();
            elevatorQueue.Enqueue(2);
            var elevator = new Elevator { Position = 0, Stops = elevatorQueue };

            elevator.Next(); elevator.Next(); elevator.Next(); elevator.Next();

            Assert.IsTrue(elevator.Time == 4);
        }
    }
}
