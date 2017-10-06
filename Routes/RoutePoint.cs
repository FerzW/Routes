using System;

namespace Routes
{
    class RoutePoint
    {
        private RoutePoint prevPoint;
        private int point;
        private int bus;
        private int time;
        private int startTime = -1;
        private int cost;

        public override String ToString()
        {
            return point.ToString() + ((bus >= 0) ? "\t" + (bus + 1).ToString() : "\t" ) + 
                    "\t" + TimeConverter.IntToTime(time).ToShortTimeString() + 
                    ((startTime >= 0) ? ("\t" + TimeConverter.IntToTime(startTime).ToShortTimeString()) : "");
        }

        public RoutePoint() { }
        public RoutePoint( int point, int bus, int time, int cost, RoutePoint prevPoint)
        {
            this.point = point;
            this.bus = bus;
            this.time = time;
            this.cost = cost;
            this.prevPoint = prevPoint;
        }
        public RoutePoint(RoutePoint curPoint)
        {
            this.point = curPoint.Point;
            this.bus = curPoint.Bus;
            this.time = curPoint.Time;
            this.cost = curPoint.Cost;
            this.prevPoint = curPoint.PrevPoint == null ? null : (RoutePoint)curPoint.PrevPoint.MemberwiseClone();
            
        }

        public RoutePoint PrevPoint
        {
            get
            {
                return prevPoint;
            }
            set
            {
                prevPoint = value;
            }
        }

        public int Point
        {
            get
            {
                return point;
            }
            set
            {
                point = value;
            }
        }

        public int Bus
        { 
            get
            {
                return bus;
            }
            set
            {
                bus = value;
            }
        }

        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
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
                        startTime = value;
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
                cost = value;
            }
        }
    }
}
