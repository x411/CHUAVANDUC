using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Framework
{
    
    public class BaseDataAccess
    {
        private DataManager _dataManager;

        /// <summary>
        /// Constructor with its Business component.
        /// </summary>
        /// <param name="baseBusiness">The Business component that contains this DataAccess component.</param>
        public BaseDataAccess(BaseBusiness baseBusiness)
        {
            this._dataManager = baseBusiness.DataManager;
        }

        /// <summary>
        /// Gets the DataManager of this DataAccess component.
        /// </summary>
        protected DataManager DataManager
        {
            get
            {
                return _dataManager;
            }
        }

        /// <summary>
        /// <see cref="SystemFramework.DataManager.BeginLoadData"/>
        /// </summary>
        /// <param name="selectCommand"></param>
        protected ConnectionStatus BeginLoadData(ref SqlCommand selectCommand)
        {
            return DataManager.BeginLoadData(selectCommand);
        }

        /// <summary>
        /// <see cref="SystemFramework.DataManager.EndLoadData"/>
        /// </summary>
        protected void EndLoadData(ConnectionStatus status)
        {
            DataManager.EndLoadData(status);
        } 
    }
}
