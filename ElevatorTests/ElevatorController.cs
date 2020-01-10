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

namespace ElevatorTests
{
    public class ElevatorController
    {
        public int GetBestElevator(Elevator[] elevators, int position, int destination)
        {
            var simulationStates = new ElevatorSimulationState[elevators.Length];

            while (true)
            {
                for (int i = 0; i < elevators.Length; i++)
                {
                    if (elevators[i].Stops.Count == 0)
                    {
                        if (simulationStates[i] == ElevatorSimulationState.Going)
                        {
                            elevators[i].Stops.Enqueue(position);
                        }

                        elevators[i].Stops.Enqueue(destination);
                    }

                    if (simulationStates[i] == ElevatorSimulationState.Going && elevators[i].Position == position)
                    {
                        simulationStates[i] = ElevatorSimulationState.PickedUp;
                    }

                    if (simulationStates[i] == ElevatorSimulationState.PickedUp && elevators[i].Position == destination)
                    {
                        simulationStates[i] = ElevatorSimulationState.Done;
                    }

                    if (simulationStates[i] == ElevatorSimulationState.Done)
                    {
                        return i;
                    }

                    elevators[i].Next();
                }
            }
        }
    }
}
