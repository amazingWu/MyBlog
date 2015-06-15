using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLoginBean.Models
{
    [Serializable]
    public partial class Tag
    {
        public Tag()
        { }
        #region Model
        private int _id;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        private int? _titleid;
        /// <summary>
        /// 标示符
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        /// <summary>
        /// 与文章关联
        /// </summary>
        public int? TitleID
        {
            set { _titleid = value; }
            get { return _titleid; }
        }
        #endregion Model

    }
}
