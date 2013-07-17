using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Web;
using System.Data;

namespace HongXiu.Mall.DAL
{
    public class MallDalBase
    {
        #region ��������

        /// <summary>
        /// ��DataReader�Զ�����T���͵�List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected List<T> BuildTByDataReader<T>(SqlDataReader reader) where T: new()
        {
            List<T> lsT = new List<T>();

            while (reader.Read())
            {
                T t = new T();
                int fieldCount = reader.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    //����
                    string fieldName = reader.GetName(i);

                    //�ֶζ���
                    FieldInfo fi = t.GetType().GetField(fieldName);

                    if (fi == null)
                        continue;

                    //�ֶ�����
                    Type fieldType = fi.FieldType;

                    //��ֵ
                    if (reader[i] != DBNull.Value)
                        fi.SetValue(t, Convert.ChangeType(reader[i], fieldType));
                }
                lsT.Add(t);
            }
            reader.Close();
            return lsT;
        }

        #region ����SQL������

        /// <summary>
        /// ����model�����Զ�����һ��sqlparameter����
        /// </summary>
        /// <param name="procut"></param>
        /// <returns></returns>
        protected List<SqlParameter> BuildSqlParameterArray(object obj, params string[] excludeField)
        {
            List<SqlParameter> lsSqlParameter = new List<SqlParameter>();

            FieldInfo[] fieldAry = obj.GetType().GetFields();
            foreach (FieldInfo fi in fieldAry)
            {
                string fieldname = fi.Name;
                if (Array.IndexOf(excludeField, fieldname) == -1)
                {
                    lsSqlParameter.Add(new SqlParameter("@" + fieldname, fi.GetValue(obj)));
                }
            }
            return lsSqlParameter;
        }

        /// <summary>
        /// ����model�����Զ�����insert sql���
        /// </summary>
        /// <param name="procut"></param>
        /// <returns></returns>
        protected string BuildInsertSQL(object obj, params string[] excludeField)
        {
            string sql = "insert into {0}({1}) values({2})";
            string tablename = obj.GetType().Name;

            List<string> lsFiled1 = new List<string>();
            List<string> lsFiled2 = new List<string>();

            FieldInfo[] fieldAry = obj.GetType().GetFields();
            foreach (FieldInfo fi in fieldAry)
            {
                string fieldname = fi.Name;
                if (Array.IndexOf(excludeField, fieldname) == -1)
                {
                    lsFiled1.Add(fieldname);
                    lsFiled2.Add("@" + fieldname);
                }
            }
            return string.Format(sql, tablename, string.Join(",", lsFiled1.ToArray()), string.Join(",", lsFiled2.ToArray()));
        }

        /// <summary>
        /// ����model�����Զ�����update sql���
        /// </summary>
        /// <param name="procut"></param>
        /// <returns></returns>
        protected string BuildUpdateSQL(object obj, int id, params string[] excludeField)
        {
            string sql = "update {0} set {1} where id={2}";
            string tablename = obj.GetType().Name;

            List<string> lsFiled1 = new List<string>();

            FieldInfo[] fieldAry = obj.GetType().GetFields();
            foreach (FieldInfo fi in fieldAry)
            {
                string fieldname = fi.Name;
                if (Array.IndexOf(excludeField, fieldname) == -1)
                {
                    lsFiled1.Add(fieldname + "=@" + fieldname);
                }
            }
            return string.Format(sql, tablename, string.Join(",", lsFiled1.ToArray()), id);
        }

        #endregion

        #endregion

        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByID<T>(int id) where T : class, new()
        {
            string tablename = typeof(T).Name;
            SqlDataReader reader = DbHelperSQL.ExecuteReader(string.Format("select * from [{0}] where id = {1}", tablename, id));
            List<T> ls = BuildTByDataReader<T>(reader);
            T t = ls.Count == 0 ? null : ls[0];
            return t;
        }

        /// <summary>
        /// ����IDɾ����¼
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelByID<T>(int id)
        {
            string tablename = typeof(T).Name;
            return DbHelperSQL.ExecuteSql(string.Format("delete from [{0}] where id = {1}", tablename, id)) != -1;
        }

        /// <summary>
        /// ���һ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="excludeField"></param>
        /// <returns></returns>
        public bool AddByObj<T>(T t, params string[] excludeField) where T : new()
        {
            List<SqlParameter> ls = BuildSqlParameterArray(t);
            return DbHelperSQL.ExecuteSql(BuildInsertSQL(t, excludeField), ls.ToArray()) != -1;
        }

		/// <summary>
        /// ���һ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="excludeField"></param>
        /// <returns></returns>
        public int AddByObj_ReturnInsertID<T>(T t, params string[] excludeField) where T : new()
        {
            List<SqlParameter> ls = BuildSqlParameterArray(t);
            object obj = DbHelperSQL.GetSingle(BuildInsertSQL(t, excludeField) +";select @@IDENTITY", ls.ToArray());
            int id = -1;
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool UpdateByObj<T>(T t, params string[] excludeField) where T : new()
        {
            int id = Convert.ToInt32(t.GetType().GetField("ID").GetValue(t));
            string sql = BuildUpdateSQL(t, id,excludeField);
            List<SqlParameter> ls = BuildSqlParameterArray(t, excludeField);
            return DbHelperSQL.ExecuteSql(sql, ls.ToArray()) != -1;
        }

        /// <summary>
        /// ��ȡһ��DataTable���ݼ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetListBySQL(string sql)
        {
            return DbHelperSQL.Query(sql).Tables[0];
        }

        /// <summary>
        /// ִ��insert��delte��update����
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql) != -1;
        }

        /// <summary>
        /// ��ȡ�������͵��б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetObjListBySQL<T>(string sql) where T : new()
        {
            SqlDataReader reader = DbHelperSQL.ExecuteReader(sql);
            return BuildTByDataReader<T>(reader);
        }
    }
}
