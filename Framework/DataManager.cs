using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System;
using System.Drawing;
using System.IO;

namespace Framework
{
    public enum ConnectionStatus
    {
        TransactionStated,
        Connected,
        Available,
        Unknow
    }
 
    public class DataManager
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        #region Properties

        /// <summary>
        /// Constructor with a connection
        /// </summary>
        /// <param name="connection">This connection is used for all command from this DataManager.</param>
        internal DataManager(ref SqlConnection connection)
        {
            this._connection = connection;
        }

        /// <summary>
        /// Sets the transaction for this DataManager
        /// </summary>
        internal SqlTransaction Transaction
        {
            set
            {
                this._transaction = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a command. All commands created from this DataManager can be used in one Transaction 
        /// </summary>
        /// <param name="sql">The query string or the stored procedure name or the table name depend on the commandType</param>
        /// <param name="commandType">The type of command</param>
        /// <returns>Return a SqlComman</returns>
        public SqlCommand CreateCommand(string sql, CommandType commandType)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.CommandType = commandType;
            sqlCommand.Connection = _connection;
            return sqlCommand;
        }

        /// <summary>
        /// Adds an Array of SqlParameter to the command
        /// </summary>
        /// <param name="command">The command want to add the parameters.</param>
        /// <param name="parameters">The name of parameter array.</param>                
        public void AddParameters(SqlCommand command, SqlParameter[] parameters)
        {
            command.Parameters.AddRange(parameters);
        }

        /// <summary>
        /// Adds SqlParameter to the command
        /// </summary>
        /// <param name="command">The command want to add the parameters.</param>
        /// <param name="parameter">The name of parameter</param>                
        public void AddParameter(SqlCommand command, SqlParameter parameter)
        {
            command.Parameters.Add(parameter);
        }

        public void AddParameterWithValue(SqlCommand command, string paramName, object value)
        {
            if (value == null)
            {
                command.Parameters.AddWithValue(paramName, DBNull.Value);
            }
            else
            {
                if (value.GetType() == typeof(DateTime))
                {
                    DateTime dt = Convert.ToDateTime(value);
                    if (dt == DateTime.MinValue)
                    {
                        command.Parameters.AddWithValue(paramName, DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(paramName, value);
                    }
                }
                else
                {
                    command.Parameters.AddWithValue(paramName, value);
                }

            }
        }

        /// <summary>
        /// Executes a command and return a number of rows affected. 
        /// This function is usually used for insert and update command 
        /// </summary>
        /// <param name="sqlCommand">The command that will be executed.</param>
        /// <returns>Number of rows affected</returns>
        public int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            if (_transaction != null)
            {
                try
                {
                    sqlCommand.Transaction = _transaction;
                    return sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return -1;
                    //throw ex;
                }
                finally
                {                    
                }
            }
            else
            {
                try
                {
                    _connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return -1;
                    //throw ex;
                }
                finally
                {
                    try
                    {
                        _connection.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public int ExecuteNonQuery(SqlCommand sqlCommand, ref int OutputResult, ref string OutputMsg)
        {

            if (_transaction != null)
            {
                try
                {
                    sqlCommand.Transaction = _transaction;
                    return sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException odbcEx)
                {
                    OutputResult = odbcEx.Number;
                    OutputMsg = odbcEx.Message;
                    return -1;
                    //throw ex;
                }
                catch (Exception ex)
                {
                    OutputResult = -1;
                    OutputMsg = "Cannot import";
                    return -1;
                    //throw ex;
                }
                finally
                {
                    OutputResult = 0;
                    OutputMsg = "Imported successfully";
                }
            }
            else
            {
                try
                {
                    _connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException odbcEx)
                {
                    OutputResult = odbcEx.Number;
                    OutputMsg = odbcEx.Message;
                    return -1;
                    //throw ex;
                }
                catch (Exception ex)
                {
                    return -1;
                }
                finally
                {
                    try
                    {
                        _connection.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        /// <summary>
        /// Executes a query and returns the first value of the first row in the result set.
        /// </summary>
        /// <param name="sqlCommand">The command that will be executed</param>
        /// <returns>The first value of the first row in the result set.</returns>
        public object ExecuteScalar(SqlCommand sqlCommand)
        {
            if (_transaction != null)
            {
                sqlCommand.Transaction = _transaction;
                return sqlCommand.ExecuteScalar();
            }
            else
            {
                try
                {
                    _connection.Open();
                    return sqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    try
                    {
                        _connection.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Return a SqlDataReader so that consumer can get data their own.
        /// It must be call CompleteReader after read all data
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(SqlCommand sqlCommand)
        {
            if (_transaction != null)
            {
                sqlCommand.Transaction = _transaction;
            }
            else
            {
                _connection.Open();
            }
            return sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Called after use ExecuteReader.
        /// </summary>
        /// <param name="reader"></param>
        public void CompleteReader(SqlDataReader reader)
        {
            try
            {
                reader.Close();
                if (_transaction == null)
                {
                    _connection.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Load Data for one property
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <param name="entityType"></param>
        public T LoadData<T>(SqlCommand selectCommand) where T : BaseEntity
        {
            T entity = null;
            SqlDataReader reader = null;
            ConnectionStatus status = ConnectionStatus.Unknow;
            try
            {
                //Open connection
                status = BeginLoadData(selectCommand);

                //Begin load Data
                reader = selectCommand.ExecuteReader();
                int columnsCount = reader.FieldCount;
                entity = Activator.CreateInstance(typeof(T)) as T;
                if (reader.Read())
                {
                    //entity = Activator.CreateInstance(typeof(T)) as T;

                    for (int i = 0; i < columnsCount; i++)
                    {
                        string propName = reader.GetName(i);
                        object value = reader[propName];
                        if (value != DBNull.Value)
                        {
                            entity.SetValue(propName, value);                           
                        }
                        else
                        {
                            entity.SetValue(propName, null);
                        }
                    }
                    entity.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                EndLoadData(status);
                try
                {
                    reader.Close();
                }
                catch (Exception) { }
            }
            return entity;
        }

        /// <summary>
        /// Load a list of data
        /// </summary>
        /// <param name="selectCommand"></param>
      
        public ObjectCollection<T> LoadListOfData<T>(SqlCommand selectCommand) where T : BaseEntity
        {
            SqlDataReader reader = null;
            ObjectCollection<T> objectsList = new ObjectCollection<T>();
            objectsList.BeginEdit();
            Type entityType = typeof(T);

            ConnectionStatus status = ConnectionStatus.Unknow;
            try
            {
                //Open connection
                status = BeginLoadData(selectCommand);

                //Begin load Data
                reader = selectCommand.ExecuteReader();
                int columnsCount = reader.FieldCount;

                while (reader.Read())
                {
                   // ConstructorInfo constructor = entityType.GetConstructor(new Type[] { });
                    T entity = Activator.CreateInstance(typeof(T)) as T;
                    entity.BeginEdit();
                    for (int i = 0; i < columnsCount; i++)
                    {
                        string propName = reader.GetName(i);
                        object value = reader[propName];
                        if (value != DBNull.Value)
                        {
                            entity.SetValue(propName, value);
                            //if (reader.GetDataTypeName(reader.GetOrdinal(propName)).ToLower().Equals("image"))
                            //{
                            //    byte[] bytes = value as byte[];

                            //    MemoryStream stream = new MemoryStream(bytes);
                            //    Image image = Bitmap.FromStream(stream);
                            //    entity.SetValue(propName, image);
                            //}
                            //else
                            //{
                            //    entity.SetValue(propName, value);
                            //}
                        }
                        else
                        {
                            entity.SetValue(propName, null);
                        }
                    }
                    entity.EndEdit();
                    objectsList.Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                EndLoadData(status);
                try
                {
                    reader.Close();
                }
                catch (Exception) { }
            }
            objectsList.EndEdit();
            objectsList.AcceptChanges();
            return objectsList;
        }

        /// <summary>
        /// Load a list of data
        /// </summary>
        /// <param name="selectCommand"></param>            
        public DataSet ExcuteQuery(SqlCommand SelectCommand)
        {
            ConnectionStatus status = ConnectionStatus.Unknow;
            status = BeginLoadData(SelectCommand);

            DataSet ds = new DataSet();            
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(SelectCommand);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                EndLoadData(status);
            }
            
            return ds;          
        }
            
        #endregion

        #region Internal Methods

        /// <summary>
        /// Begins load a list of data. When this method is called, 
        /// EndLoadData() method must be call after loads data successful.
        /// e.g.
        /// <example>Try
        ///       BeginLoadData(selectCommand)
        /// Catch
        ///       'Handles exceptions
        /// Finally
        ///       EndLoadData()
        /// End Try
        /// </summary>
        /// <param name="selectCommand">The select command that is used to load data</param>
        internal ConnectionStatus BeginLoadData(SqlCommand selectCommand)
        {
            if (_transaction != null)
            {
                selectCommand.Transaction = _transaction;
                return ConnectionStatus.TransactionStated;
            }
            else if (_connection.State == ConnectionState.Open)
            {
                return ConnectionStatus.Connected;
            }
            else
            {
                _connection.Open();
                return ConnectionStatus.Available;
            }
        }

        /// <summary>
        /// End load data is used to close the connection (if it is opened by the BeginLoadData())
        /// </summary>
        internal void EndLoadData(ConnectionStatus status)
        {
            if (status == ConnectionStatus.Available)
            {
                try
                {
                    _connection.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion
    }
}
