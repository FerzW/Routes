using System;
using System.Collections.Generic;
using System.IO;

namespace Routes
{
    class Transport
    {
        private int busCount;
        private int busStopsCount = 0;
        private Bus[] busArray;
        
        public bool loadScheduleFile(string filePath)
        {
            try
            {
                using (StreamReader schedule = new StreamReader(filePath))
                {
                    string buf;

                    buf = schedule.ReadLine(); //Read bus count
                    busCount = int.Parse(buf);
                    busArray = new Bus[busCount];
                    for (int i = 0; i < busCount; i++)
                    {
                        busArray[i] = new Bus(i + 1);
                    }

                    buf = schedule.ReadLine(); //Read stops count
                    busStopsCount = int.Parse(buf);

                    buf = schedule.ReadLine(); //Read start times of bus
                    string[] timesStrArr = buf.Split(' ');
                    for (int i = 0; i < busCount; i++)
                    {
                        busArray[i].StartTimeDT = DateTime.Parse(timesStrArr[i]);
                    }
                    //Нет доп.проверок, т.к. файл корректен по условию. 
                    //Если это внезапно не тот файл - завершим разбор по ошибке.

                    buf = schedule.ReadLine(); //Read costs of bus
                    string[] costsStrArr = buf.Split(' ');
                    for (int i = 0; i < busCount; i++)
                    {
                        busArray[i].Cost = int.Parse(costsStrArr[i]);
                    }

                    for (int i = 0; i < busCount; i++) //Read route info for each bus
                    {
                        buf = schedule.ReadLine();
                        int[] bufArr = Array.ConvertAll(buf.Split(' '), int.Parse);
                        for (int j = 0; j < bufArr[0]; j++)
                        {
                            busArray[i].AddStop(bufArr[j + 1]);
                            busArray[i].AddInterval(bufArr[j + 1 + bufArr[0]]);
                        }
                    }

                    schedule.Close();
                }
            }
            catch(Exception e)
            {
                return false;
                // Т.к. по условию предполагается загрузка корректного файл
                // - простая обработка:
                // что-то не вышло - ничего не делаем, отменяем открытие
            }
            return true;
        }

        public int BusStopsCount
        {
            get
            {
                return busStopsCount;
            }
        }

        public List<int> BusStops
        {
            get
            {
                List<int> busStops = new List<int>(busStopsCount);
                for (int i = 1; i <= busStopsCount; i++)
                {
                    busStops.Add(i);
                }
                return busStops;
            }
        }

        int startPoint = 0;
        int endPoint = 0;
        int startTime = 0;

        List<RoutePoint> fastRoute = new List<RoutePoint>();
        List<RoutePoint> cheapRoute = new List<RoutePoint>();

        public bool FindRoutes(int startBusStop, int finishBusStop, DateTime startTime)
        {
            return FindRoutes(startBusStop, finishBusStop, TimeConverter.TimeToInt(startTime));
        }

        public bool FindRoutes(int startBusStop, int finishBusStop, int startTime)
        {
            fastRoute.Clear();
            cheapRoute.Clear();
            startPoint = startBusStop;
            endPoint = finishBusStop;
            this.startTime = startTime;

            RoutePoint firstPoint = new RoutePoint();
            firstPoint.PrevPoint = null;
            firstPoint.Point = startPoint;
            firstPoint.Cost = 0;
            firstPoint.Bus = -1;
            firstPoint.Time = startTime;

            List<int> listBusIndexes = new List<int>();
            for (int i = 0; i<busCount; i++)
            {
                listBusIndexes.Add(i);
            }

            return NextPoint(listBusIndexes, firstPoint, -1);
        }

        public bool NextPoint(List<int> avaliableBuses, RoutePoint curPoint, int stopsCnt)
        {
            bool result = false;
            if (curPoint.Point == endPoint)
            {
                if(TimeConverter.timeIsCorrect(curPoint.Time))
                {
                    if ( fastRoute.Count == 0 )
                    {
                        fastRoute = HistoryToList(curPoint);
                        result = true;
                    }
                    else if ( fastRoute[fastRoute.Count-1].Time > curPoint.Time)
                    {
                        fastRoute = HistoryToList(curPoint);
                        result = true;
                    }

                    if (cheapRoute.Count == 0)
                    {
                        cheapRoute = HistoryToList(curPoint);
                        result = true;
                    }
                    else if (cheapRoute[cheapRoute.Count - 1].Cost > curPoint.Cost)
                    {
                        cheapRoute = HistoryToList(curPoint);
                        result = true;
                    }
                }
            }
            else
            {
                if (curPoint.Point != startPoint)
                {
                    result |= NextPointThisBus(avaliableBuses, new RoutePoint(curPoint), stopsCnt - 1);
                }
                foreach (int bus in avaliableBuses)
                {
                    result |= NextPointAnotherBus(new List<int>(avaliableBuses), new RoutePoint(curPoint), bus);
                }
            }
            return result;
        }

        public bool NextPointThisBus(List<int> avaliableBuses, RoutePoint curPoint, int stopsCnt)
        {
            if (stopsCnt <= 0) return false;
            else
            {
                RoutePoint nextPoint = busArray[curPoint.Bus].nextStop(curPoint);
                if (nextPoint.Point < 0) return false;
                else
                {
                    nextPoint.Cost = curPoint.Cost;
                    return NextPoint(avaliableBuses, nextPoint, stopsCnt);
                }
            }
        }

        public bool NextPointAnotherBus(List<int> avaliableBuses, RoutePoint curPoint, int bus)
        {
            avaliableBuses.Remove(bus);
            RoutePoint nextPoint = busArray[bus].nextStop(curPoint,bus);
            if (nextPoint.Point < 0) return false;
            else
            {
                nextPoint.Cost += curPoint.Cost;
                return NextPoint(avaliableBuses, nextPoint, busArray[bus].BusStops.Count-1);
            }
        }

        private List<RoutePoint> HistoryToList(RoutePoint lastPoint)
        {
            List<RoutePoint> routeList = new List<RoutePoint>();
            RoutePoint tempPoint = lastPoint;
            for(; tempPoint!=null; )
            {
                routeList.Add(tempPoint);
                tempPoint = tempPoint.PrevPoint;
            }
            routeList.Reverse();
            return routeList;
        }

        public List<RoutePoint> FastRoute
        {
            get { return fastRoute; }
        }

        public List<RoutePoint> CheapRoute
        {
            get { return cheapRoute; }
        }
    }
}
