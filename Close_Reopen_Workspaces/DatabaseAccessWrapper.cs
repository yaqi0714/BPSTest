using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Close_Reopen_Workspaces
{
    internal class DatabaseAccessWrapper
    {
        /// <summary>
        ///  executes the specified query and returns the results as table.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns>Xml results</returns>
        internal static bool ExecuteCmdAndReturnTable(string query, string connectionString, out DataTable tblReturn)
        {
            bool success = true;

            tblReturn = new System.Data.DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adpter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adpter.Fill(tblReturn);
                }
                catch (Exception e)
                {
                    List<KeyValuePair<string, string>> info = new List<KeyValuePair<string, string>>();
                    info.Add(new KeyValuePair<string, string>("Query", query));
                    info.Add(new KeyValuePair<string, string>("ConnectionString", connectionString));
                    info.Add(new KeyValuePair<string, string>("ErrorMessage", e.Message));

                    EventLogger.WriteEventLog(Utility.BuildMessage(info));
                    success = false;
                }
                finally
                {
                    if (connection != null && (connection.State == System.Data.ConnectionState.Open))
                        connection.Close();
                }
            }

            return success;
        }

        /// <summary>
        ///  executes the insert command
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns>Xml results</returns>
        internal static bool ExecuteInsertCmd(string query, string connectionString, ref int rowCountInserted)
        {
            bool success = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.InsertCommand = new SqlCommand(query, connection);
                    rowCountInserted = adapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    List<KeyValuePair<string, string>> info = new List<KeyValuePair<string, string>>();
                    info.Add(new KeyValuePair<string, string>("Query", query));
                    info.Add(new KeyValuePair<string, string>("ConnectionString", connectionString));
                    info.Add(new KeyValuePair<string, string>("ErrorMessage", e.Message));

                    EventLogger.WriteEventLog(Utility.BuildMessage(info));
                    success = false;
                }
                finally
                {
                    if (connection != null && (connection.State == System.Data.ConnectionState.Open))
                        connection.Close();
                }
            }

            return success;
        }

        /// <summary>
        ///  executes the update command
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns>Xml results</returns>
        internal static bool ExecuteUpdateCmd(string query, string connectionString, ref int rowCountUpdated)
        {
            bool success = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.UpdateCommand = new SqlCommand(query, connection);
                    rowCountUpdated = adapter.UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    List<KeyValuePair<string, string>> info = new List<KeyValuePair<string, string>>();
                    info.Add(new KeyValuePair<string, string>("Query", query));
                    info.Add(new KeyValuePair<string, string>("ConnectionString", connectionString));
                    info.Add(new KeyValuePair<string, string>("ErrorMessage", e.Message));

                    EventLogger.WriteEventLog(Utility.BuildMessage(info));
                    success = false;
                }
                finally
                {
                    if (connection != null && (connection.State == System.Data.ConnectionState.Open))
                        connection.Close();
                }
            }

            return success;
        }

        /// <summary>
        ///  executes the delete command
        /// </summary>
        /// <param name="query"></param>
        /// <param name="connectionString"></param>
        /// <returns>Xml results</returns>
        internal static bool ExecuteDeleteCmd(string query, string connectionString, ref int rowCountDeleted)
        {
            bool success = true;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                try
                {
                    connection.Open();
                    adapter.DeleteCommand = new SqlCommand(query, connection);
                    rowCountDeleted = adapter.DeleteCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    List<KeyValuePair<string, string>> info = new List<KeyValuePair<string, string>>();
                    info.Add(new KeyValuePair<string, string>("Query", query));
                    info.Add(new KeyValuePair<string, string>("ConnectionString", connectionString));
                    info.Add(new KeyValuePair<string, string>("ErrorMessage", e.Message));

                    EventLogger.WriteEventLog(Utility.BuildMessage(info));
                    success = false;
                }
                finally
                {
                    if (connection != null && (connection.State == System.Data.ConnectionState.Open))
                        connection.Close();
                }
            }

            return success;
        }

        public class StoredProcedure
        {
            protected SqlCommand command;

            protected string procedureName;

            protected string connectionString;

            protected List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string,string>>();

            public StoredProcedure(string _procedureName, string connection)
            {
                this.procedureName = _procedureName;
                this.connectionString = connection;
                command = new SqlCommand();
                command.CommandText = _procedureName;
                command.Connection = new SqlConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection.ConnectionString = connection;
            }

            public SqlCommand Command
            {
                get { return command; }
            }

            /// <summary>
            /// adds a string type parameter to the parameter list
            /// </summary>
            public void AddCommandParameter(string name, string value, int size)
            {
                SqlParameter param = command.Parameters.Add(name, SqlDbType.VarChar, size);
                param.Value = value;
                parameters.Add(new KeyValuePair<string, string>(name, value));
            }

            /// <summary>
            /// adds a int type parameter to the parameter list
            /// </summary>
            public void AddCommandParameter(string name, int value)
            {
                SqlParameter param = command.Parameters.Add(name, SqlDbType.Int);
                param.Value = value;
                parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
            }

            /// <summary>
            /// adds a bool type parameter to the parameter list
            /// </summary>
            public void AddCommandParameter(string name, bool value)
            {
                SqlParameter param = command.Parameters.Add(name, SqlDbType.Bit);
                param.Value = value;
                parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
            }

            /// <summary>
            /// adds a date time parameter to the parameter list
            /// </summary>
            public void AddCommandParameter(string name, DateTime value)
            {
                SqlParameter param = command.Parameters.Add(name, SqlDbType.DateTime);
                param.Value = value;
                parameters.Add(new KeyValuePair<string, string>(name, value.ToString()));
            }

            /// <summary>
            /// adds a date time parameter to the parameter list
            /// </summary>
            public bool ExecuteNoReturn()
            {
                bool success = true;

                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    List<KeyValuePair<string, string>> info = new List<KeyValuePair<string, string>>();
                    info.Add(new KeyValuePair<string, string>("ErrorMessage", e.Message));
                    info.Add(new KeyValuePair<string, string>("ConnectionString", connectionString));
                    info.AddRange(parameters);

                    EventLogger.WriteEventLog(Utility.BuildMessage(info));
                    success = false;
                }
                finally
                {
                    if (command.Connection != null && (command.Connection.State == System.Data.ConnectionState.Open))
                        command.Connection.Close();
                }
                return success;
            }

            public bool ExecuteAndReturnTable(out DataTable tblReturn)
            {
                bool success = true;

                tblReturn = new System.Data.DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adpter = new SqlDataAdapter(command);
                    try
                    {
                        connection.Open();
                        adpter.Fill(tblReturn);
                    }
                    catch (Exception e)
                    {
                        List<KeyValuePair<string, string>> info = new List<KeyValuePair<string, string>>();
                        info.Add(new KeyValuePair<string, string>("ErrorMessage", e.Message));
                        info.Add(new KeyValuePair<string, string>("ConnectionString", connectionString));
                        info.AddRange(parameters);

                        EventLogger.WriteEventLog(Utility.BuildMessage(info));
                        success = false;
                    }
                    finally
                    {
                        if (connection != null && (connection.State == System.Data.ConnectionState.Open))
                            connection.Close();
                    }
                }

                return success;
            }
        }
    }
}
