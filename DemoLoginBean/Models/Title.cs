using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginBean.Models
{
    [Serializable]
    public partial class Title
    {
        public Title()
        { }
        #region Model
        private int _id;
        private string _tname;
        private DateTime _ttime;
        private int _tuserid;
        private string _tcontent;
        public string uName { get; set; }
        public Tag tag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tName
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime tTime
        {
            set { _ttime = value; }
            get { return _ttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int tUserID
        {
            set { _tuserid = value; }
            get { return _tuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tContent
        {
            set { _tcontent = value; }
            get { return _tcontent; }
        }

        
        #endregion Model

    }
}
