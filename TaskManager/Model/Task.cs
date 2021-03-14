using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager.Model
{
    public enum DegreeOfImportance
    {
        Immediate,
        Important,
        NonUrgent
    }
    public class Task
    {
        private string title;
        private DateTime deadline;
        private string description;
        private DegreeOfImportance importance;
        private List<string> tags;
        private bool isPerfomed = false;

        public string Title { get => title; set => title = value; }
        public DateTime Deadline { get => deadline.Date; set => deadline = value.Date; }
        public string Description { get => description; set => description = value; }
        public DegreeOfImportance Importance { get => importance; set => importance = value; }
        public List<string> Tags { get => tags; set => tags = value; }
        public bool IsPerfomed { get => isPerfomed; set => isPerfomed = value; }
        public bool IsExpired { 
            get 
            {
                if (isPerfomed) return false;
                if(deadline.Date < DateTime.Now.Date)
                {
                    return true;
                }
                return false;
            } 
        }
        public int AmountOfDaysRemaining { get => (int)Deadline.Subtract(DateTime.Today).TotalDays; }
        public string AmountOdDaySRemainingFormater
        {
            get
            {
                if (AmountOfDaysRemaining < 0) return "";
                else if (AmountOfDaysRemaining == 0) return "(today)";
                else if (AmountOfDaysRemaining == 1) return $"({AmountOfDaysRemaining} day left)";
                else return $"({AmountOfDaysRemaining} days left)";
            }
        }
        public string DeadlineFormater { get => Deadline.Date.ToShortDateString(); }

        public Task() { }
        public Task(string title, DateTime deadline, string description, DegreeOfImportance importance, string tags)
        {
            this.title = title;
            this.deadline = deadline;
            this.description = description;
            this.importance = importance;
            this.tags = ParseTags(tags);
        }
        public Task(Task task)
        {
            title = task.Title;
            deadline = task.Deadline;
            description = task.Description;
            importance = task.Importance;
            tags = task.Tags;
        }

        public override string ToString()
        {
            return title;
        }

        public List<string> ParseTags(string tags)
        {
            List<string> tempTags = new List<string>();
            string temp = String.Empty;
            if(tags != null)
            {
                foreach(char x in tags)
                {
                    if(x == '#')
                    {
                        temp = temp.Replace(",", "").Replace(" ", "");
                        tempTags.Add(temp);
                        temp = String.Empty;
                        temp += x;
                    }
                    else
                    {
                        temp += x;
                    }
                }
                if ((tags.Count()!=0))
                {
                    if((tags[tags.Count() - 1] != ' ' || tags[tags.Count() - 1] != ','))
                    {
                        temp = temp.Replace(",", "").Replace(" ", "");
                        tempTags.Add(temp);
                    }
                    tempTags.RemoveAt(0);
                }
            }
            return tempTags;
        }
    }
}
