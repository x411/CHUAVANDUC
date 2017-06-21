using System.Data.SqlClient;
using System;
using System.Data;

namespace Framework
{
    public abstract class BaseBusiness
    {
        private DataManager _dataManager;
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseBusiness()
        {
            _connection = ConnectionManager.GetConnection();
            _dataManager = new DataManager(ref _connection);
        }

        /// <summary>
        /// Gets the DataManager of this business component. This DataManager is used in the whole data access component of this business component.
        /// </summary>
        internal DataManager DataManager
        {
            get
            {
                return _dataManager;
            }
        }

        /// <summary>
        /// This function is used for load a large amount of data those associate with many DataAccess classes
        /// </summary>
        public void OptimizeForLoadData()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method is called when data is loaded and after call OptimizeForLoadData().
        /// </summary>
        public void CompleteLoadData()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Begins a transaction
        /// </summary>
        public void BeginTransaction()
        {
            try
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                _dataManager.Transaction = _transaction;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Commits a transaction if all the data operation is successfully.
        /// </summary>
        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Commit();
                    _connection.Close();
                    _transaction = null;
                    _dataManager.Transaction = null;
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Rolls back all data if there is at least one operation fail.
        /// </summary>
        public void RollBackTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Rollback();
                    _connection.Close();
                    _transaction = null;
                    _dataManager.Transaction = null;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
