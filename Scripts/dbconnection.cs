using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;

public class dbconnection : MonoBehaviour {

    public static int[] control = new int [2];
    public  static SqliteConnection dbconn;
    public static SqliteCommand dbcmd;
    public static int recordcount,questionedcount;
    
    public void Start()
    {   //file:C:/db4project/ProjectDB.s3db

        // path = "jar:file://" + Application.dataPath + "!/assets/";

        string conn = "URI=file:"+Application.dataPath+ "/StreamingAssets/ProjectDB.s3db"; //Path to database.
      // string conn = "jar:file://" + Application.dataPath + "!/assets/ProjectDB.s3db";
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        recordcount=getrecordcount(dbconn, dbcmd);

        executequeries(dbconn,dbcmd);

    }
    public static string SqlQuery(int index) {

       
        string sqlQuery = "SELECT *  FROM Questions q JOIN Options o using (QuestionID) where QuestionID = '" + index + "'"; //sql sorgusu
        return sqlQuery;
        
        }
        public static int getRandomQuestionIndex(int range)
        {
        int randomint = Random.Range(1,range+1);

          return randomint;
        }

        public static void executequeries(SqliteConnection dbconn,SqliteCommand dbcmd)
        {
        

            FindObjects fo = new FindObjects();
            int x = 0;
            byte[] picbytes;
            string question = "";
            Texture2D[] tex = new Texture2D[2];

       

            dbcmd = dbconn.CreateCommand();
            dbcmd.CommandText = SqlQuery(recordcount);
           SqliteDataReader reader = dbcmd.ExecuteReader();

       
        //okuma
        if (reader.HasRows == true)
            {
                while (reader.Read())
                {
                    question = reader.GetString(1);
                    control[x] = reader.GetInt32(4);
                    picbytes = (byte[])reader["pic"];
                    tex[x] = new Texture2D(16, 16, TextureFormat.PVRTC_RGBA4, false);
                    tex[x].LoadImage(picbytes);
                    tex[x].Apply();
                    x++;
                }
            }

            fo.findtexture(tex);
            fo.findtext(question);

        
        reader.Close();
        reader = null;

        if (recordcount == 1)
        {
            recordcount = getrecordcount(dbconn, dbcmd);
        }
        else
        {
            recordcount--;
        }

    }
    public static int getrecordcount(SqliteConnection dbconn, SqliteCommand dbcmd)
    {
        int records = 0;
        string recordcountquery = "select count(*) from Questions";
        dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = recordcountquery;
        SqliteDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            records = reader.GetInt32(0);
        }
        return records;
    }
       

}
	
	

