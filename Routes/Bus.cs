using System;
using System.Collections.Generic;
using System.Linq;

namespace Routes
{
    class Bus
    {
        private int number;
        private int cost;
        private int startTime;
        private List<int> busStops = new List<int>();
        private List<int> intervals = new List<int>();

        private bool roundTimeCorrect = false;
        private int roundTime;

        public Bus()
        {
        }

        public Bus(int number)
        {
            this.number = number;
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                this.cost = value;
            }
        }

        public DateTime StartTimeDT
        {
            get
            {
                return TimeConverter.IntToTime(startTime);
            }
            set
            {
                this.startTime = TimeConverter.TimeToInt(value);
            }
        }

        public int StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                this.startTime = value;
            }
        }

        public bool AddStop(int stopNumber)
        {
            roundTimeCorrect = false;
            busStops.Add(stopNumber);
            return compStopsIntervals();
        }

        public bool AddInterval(int interval)
        {
            roundTimeCorrect = false;
            intervals.Add(interval);
            return compStopsIntervals();
        }

        private bool compStopsIntervals()
        {
            if (intervals.Count() != busStops.Count())
                return false;
            else
                return true;
        }

        public List<int> BusStops
        {
            get
            {
                return busStops;
            }
        }

        public List<int> Intervals
        {
            get
            {
                return intervals;
            }
        }

        private int RoundTime
        {
            get
            {
                if (roundTimeCorrect)
                    return roundTime;
                else
                {
                    roundTime = 0;
                    foreach (int interval in intervals)
                        roundTime += interval;
                    roundTimeCorrect = true;
                    return roundTime;
                }
            }
        }

        public int nextArriving(int busStop, int time)
        {
            int lastLapTime = time - time % RoundTime;
            if (!busStops.Contains(busStop))
                return -2;
            else
            {
                for (; lastLapTime < time;)
                {
                    for (int i = 0;
                            i < BusStops.Count &&
                            !(lastLapTime >= time && busStops[i] == busStop);
                            i++)
                    {
                        lastLapTime += intervals[i];
                    }
                }
                return TimeConverter.timeIsCorrect(lastLapTime) ? lastLapTime : -1;
            }
        }

        public int nextArrivingIndex(int busStop, int time)
        {
            int lastLapTime = time - time % RoundTime;
            if (!busStops.Contains(busStop))
                return -2;
            else
            {
                int i = 0;
                for (; lastLapTime < time;)
                {
                    for (   i = 0;
                            i < BusStops.Count &&
                            !(lastLapTime >= time && busStops[i] == busStop);
                            i++)
                    {
                        lastLapTime += intervals[i];
                    }
                }
                return i;
            }
        }

        public RoutePoint nextStop(RoutePoint curStop)
        {
            return nextStop(curStop, curStop.Bus);
        }

        public RoutePoint nextStop(RoutePoint curStop, int nextBus)
        {
            int lastLapTime = curStop.Time > this.startTime ? 
                                curStop.Time - (curStop.Time - this.startTime) % RoundTime : 
                                this.startTime;
            if (!busStops.Contains(curStop.Point))
                return new RoutePoint(-2, nextBus, -2, -2, curStop);
            else
            {
                int i = 0;
                for (; lastLapTime < curStop.Time || 
                        (busStops[i % busStops.Count] != curStop.Point && TimeConverter.timeIsCorrect(lastLapTime));
                        )
                {
                    for ( i = 0;
                            i < BusStops.Count &&
                            !(lastLapTime >= curStop.Time && busStops[i] == curStop.Point);
                            i++)
                    {
                        lastLapTime += intervals[i];
                    }
                }
                int curPointIndex = i;
                curStop.StartTime = lastLapTime;
                return new RoutePoint(  busStops[(curPointIndex+1) % busStops.Count],
                                        nextBus, 
                                        lastLapTime + intervals[curPointIndex % busStops.Count], 
                                        Cost, 
                                        curStop );
            }
        }
    }
}
