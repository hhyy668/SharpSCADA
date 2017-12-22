using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.GridFS;
using System.IO;

namespace zxw.MongoDB
{
    class MongoDBConn
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private string conn =ConfigurationManager.AppSettings["MongoDBConn"];
        /// <summary>
        /// 指定的数据库
        /// </summary>
        private const string dbName = "FileDB";
        /// <summary>
        /// 指定的表
        /// </summary>
        private const string tbName = "FileTable";
         //创建数据连接
        MongoServer server;
         //获取指定数据库
        public MongoDatabase db;
         //获取表
        public MongoCollection col;
        public MongoGridFS fs;

        public MongoDBConn()
        {
            server = MongoServer.Create(conn);
            db = server.GetDatabase(dbName);
            col = db.GetCollection(tbName);
            fs = new MongoGridFS(db, new MongoGridFSSettings() { Root = "myFile" });//
        }
    }
    public class GridFS
    {
        public static string GridFsSave(byte[] byteFile)
        {
            try
            {
                MongoDBConn dbconn = new MongoDBConn();
                string filename = Guid.NewGuid().ToString();
                MongoGridFSFileInfo info = new MongoGridFSFileInfo(dbconn.fs, filename);
                using (MongoGridFSStream gfs = info.Create())
                {
                    gfs.Write(byteFile, 0, byteFile.Length);
                }
                return filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static byte[] GridFsRead(string filename)
        {
            try
            {
                MongoDBConn dbconn = new MongoDBConn();
                byte[] bytes = null;
                using (MongoGridFSStream gfs = dbconn.fs.Open(filename, FileMode.Open))
                {
                    bytes = new byte[gfs.Length];
                    gfs.Read(bytes, 0, bytes.Length);
                }
                return bytes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GridFsDelete(string filename)
        {
            try
            {
                MongoDBConn dbconn = new MongoDBConn();
                dbconn.fs.Delete(filename);
                return filename;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
