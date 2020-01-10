using System.Collections.Generic;

namespace ElevatorTests
{
    public class Constants
    {
        public const int ElevatorSpeed = 1;
        public const int ElevatorStopWaitTimePerTurn = 1;
        public const int StopAndGoWaitTurns = 2;
    }

    public enum ElevatorSimulationState
    {
        Going = 0,
        PickedUp,
        Done
    }

    public class Elevator
    {
        private int _stopCounter = 0;

        public int Time { get; set; } = 0;
        public int Position { get; set; }
        public Queue<int> Stops { get; set; }

        public void Next()
        {
            if (Stops.Count == 0)
            {
                return;
            }

            if (Position == Stops.Peek())
            {
                _stopCounter++;
                Time += Constants.ElevatorStopWaitTimePerTurn;

                if (_stopCounter == Constants.StopAndGoWaitTurns)
                {
                    _stopCounter = 0;
                    Stops.Dequeue();
                }
            }
            else
            {
                Time += Constants.ElevatorSpeed;
                Position = Position > Stops.Peek() ? Position - 1 : Position + 1;
            }
        }
    }
}
