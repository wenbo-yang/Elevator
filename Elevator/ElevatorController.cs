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
