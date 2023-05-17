using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace TemplateFw.Shared.Helpers.SqlDataHelpers
{

    public class SqlDataHelper
    {
        private string _connectionString = null;
        public SqlDataHelper(string connectionString)
        {
            _connectionString = connectionString;
        }


        #region --------------GetSqlConnection--------------
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
        #endregion

        public List<T> RetrieveEntityList<T>(string procedureName, params SqlParameter[] commandParameters)
        {
            return RetrieveEntityList<T>(procedureName, commandParameters.ToList());
        }
        public List<T> RetrieveEntityList<T>(string procedureName, List<SqlParameter> parameters)
        {
            List<T> itemsList = new List<T>();
            using (SqlConnection myConnection = GetSqlConnection())
            {

                SqlCommand myCommand = new SqlCommand(procedureName.Trim(), myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (SqlParameter p in parameters)
                    {
                        myCommand.Parameters.Add(p);
                    }
                }
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader();
                while (dr.Read())
                {
                    T item = GetEntity<T>(dr);
                    if (item != null)
                    {
                        itemsList.Add(item);
                    }
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }



        #region --------------GetEntity--------------
        //---------------------------------------------------------------------
        //GetEntity
        //---------------------------------------------------------------------
        /// <summary>
        /// conver datareader object to an entity object
        /// </summary>
        /// <param name="reader">data reader </param>
        /// <param name="t">type of object we need to convert to</param>
        /// <returns></returns>
        private T GetEntity<T>(IDataReader reader)
        {
            Type t = typeof(T);
            return (T)GetEntity(reader, t);
        }
        //---------------------------------------------------------------------
        private object GetEntity(IDataReader reader, Type t)
        {


            object obj = Activator.CreateInstance(t);
            //object obj = new t();
            StringDictionary columnsNames = new StringDictionary();
            DataTable dt = reader.GetSchemaTable();
            Type nullableType;
            object value;
            object safeValue;
            //---------------------------------
            string columnname;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                columnname = reader.GetName(i);
                if (!columnsNames.ContainsKey(columnname))
                {
                    columnsNames.Add(columnname, null);
                    PropertyInfo myPropInfo;
                    myPropInfo = t.GetProperty(columnname);
                    value = reader[columnname];

                    if (value != DBNull.Value && myPropInfo != null)
                    {
                        //myPropInfo.SetValue(obj, Convert.ChangeType(value, myPropInfo.PropertyType), null);
                        //if (myPropInfo.PropertyType.BaseType == typeof(System.Enum))
                        if (myPropInfo.PropertyType.IsEnum)
                        {

                            //int intVal = Convert.ToInt32(attr.Value);
                            myPropInfo.SetValue(obj, Enum.Parse(myPropInfo.PropertyType, value.ToString()), null);
                            //Enum.Parse(typeof(myPropInfo.), "FirstName");   
                        }
                        /*
                        else if (value.GetType() == typeof(Byte[]))
                        {
                            byte[] buf = (byte[])value;
                            myPropInfo.SetValue(obj, Convert.ChangeType(OurSerializer.Deserialize(buf), myPropInfo.PropertyType), null);
                        }
                        */
                        else if (Nullable.GetUnderlyingType(myPropInfo.PropertyType) != null)
                        {
                            nullableType = Nullable.GetUnderlyingType(myPropInfo.PropertyType) ?? myPropInfo.PropertyType;
                            if (value != null)
                            {
                                if (nullableType.IsEnum)
                                {
                                    object enumValue = Enum.ToObject(nullableType, value);
                                    myPropInfo.SetValue(obj, enumValue);
                                }
                                else
                                {
                                    safeValue = Convert.ChangeType(value, nullableType);
                                    myPropInfo.SetValue(obj, safeValue);
                                }
                            }
                        }
                        else
                        {
                            myPropInfo.SetValue(obj, Convert.ChangeType(value, myPropInfo.PropertyType), null);
                        }
                    }
                }
            }
            //---------------------------------
            return obj;
        }


        #endregion








        #region --------------RetrieveEntitySingleOrDefault--------------


        public T RetrieveEntitySingleOrDefault<T>(string procedureName, params SqlParameter[] commandParameters)
        {
            return RetrieveEntitySingleOrDefault<T>(procedureName, commandParameters.ToList());
        }
        public T RetrieveEntitySingleOrDefault<T>(string procedureName, List<SqlParameter> parameters)
        {
            Type t = typeof(T);
            List<T> list = RetrieveEntityList<T>(procedureName, parameters);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return (T)Activator.CreateInstance(t);
            }
        }
        #endregion


        #region --------------RetrieveEntity--------------



        public T RetrieveEntity<T>(string procedureName, List<SqlParameter> parameters)
        {
            Type t = typeof(T);
            List<T> list = RetrieveEntityList<T>(procedureName, parameters);
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return default(T);
            }
        }
        #endregion




        #region --------------RetrieveEntityList--------------
        public List<T> RetrieveEntityList<T>(string procedureName)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            return RetrieveEntityList<T>(procedureName, parameters);
        }


        #endregion




    }
}