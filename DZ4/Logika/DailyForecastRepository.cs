using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Logika
{
    public class DailyForecastRepository: IEnumerable<DailyForecast>
    {
        private List<DailyForecast> days;
    
        public DailyForecastRepository()
        {
            this.days = new List<DailyForecast>();
        }

        public DailyForecastRepository(DailyForecastRepository dailyForecastRepository) : this()
        {
            foreach(DailyForecast dailyForecast in dailyForecastRepository.days)
            {
                DailyForecast copy = new DailyForecast(dailyForecast.DateProperty, dailyForecast.Weather);
                this.days.Add(copy);
            }
        }

        public IEnumerator<DailyForecast> GetEnumerator()  
        {
           
            return days.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(DailyForecast day)
        {
            DateTime date;

            
            for (int i = 0; i < days.Count; i++)
            {
                
                date = days[i].DateProperty.Date;
              

                if(date==day.DateProperty.Date)
                {
                    
                    days[i] = day;
                    return;
                   
                }
                
            }

            this.days.Add(day);

        }


        public void Add(List<DailyForecast> days2)
        {
            

            for (int i=0;i<days.Count;i++)
            {
                for(int j=0;j<days2.Count;j++)
                {
                    if(days[i].DateProperty.Date==days2[j].DateProperty.Date)
                    {
                        
                        days[i] = days2[j];
                        days2.RemoveAt(j);
                    }
                }
            }
            days.AddRange(days2);
           
        }

        public void Remove(DateTime date)
        {
            int removableIndex = 0;
            int remove = 0;
                
            for(int i=0;i<days.Count;i++)
            {
                if(days[i].DateProperty==date)
                {
                    remove++;
                    removableIndex = i;
                   
                }
                
            }

             if (remove == 0)
                 throw new NoSuchDailyWeatherException($"The date {date} could not be removed, it doesn't exist");
             if (remove > 1)
                 throw new NoSuchDailyWeatherException($"There are multiple dates like {date}, therefore it could't be removed ");

             days.RemoveAt(removableIndex);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, days);
        }
    }
}
