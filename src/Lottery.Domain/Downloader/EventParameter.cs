using System;

namespace Lottery.Downloader
{
    public class EventParameter
    {
        private string _name;
        private string _type;
        private string _dbName;
        private string _downUrl;
        private DateTime _endDate;
        private DateTime _startDate;
        private int _startIndex;
        private int _endIndex;
        
        public EventParameter(string type, string name,string downUrl,string dbName)
        {
            this._type = type;
            this._name = name;
            this._downUrl = downUrl;
            this._dbName = dbName;
        }

        public string Name
        {
            get { return this._name; }
        }

        public string Type
        {
            get { return this._type; }
        }

        public string DownUrl
        {
            get { return this._downUrl; }
        }

        public string DbName
        {
            get { return this._dbName; }
        }

        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public DateTime EndDate
        {
            get{ return this._endDate;}
            set { this._endDate = value; }
        }

        public int StartIndex
        {
            get { return this._startIndex; }
            set { this._startIndex = value; }
        }

        public int EndIndex
        {
            get { return this._endIndex; }
            set { this._endIndex = value; }
        }
    }
}

