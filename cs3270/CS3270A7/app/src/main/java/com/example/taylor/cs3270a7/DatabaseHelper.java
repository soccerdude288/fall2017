package com.example.taylor.cs3270a7;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

/**
 * Created by taylor on 10/10/17.
 */

public class DatabaseHelper extends SQLiteOpenHelper{
    private SQLiteDatabase database;

    public DatabaseHelper(Context context, String name, SQLiteDatabase.CursorFactory factory, int version){
        super(context, name, factory,version);
    }


    public SQLiteDatabase open(){
        database = getWritableDatabase();
        return database;
    }

    public void close(){
        if(database != null){
            database.close();
        }
    }

    public long insertClass(String id, String name, String course, String start, String end){
        long rowID = -1;

        ContentValues newClass = new ContentValues();
        newClass.put("id", id);
        newClass.put("name", name);
        newClass.put("course", course);
        newClass.put("start", start);
        newClass.put("end", end);

        if(open()!=null){
            rowID = database.insert("classes", null, newClass);
            close();
        }
        return rowID;
    }

    public long updateClass(long _id ,String id, String name, String course, String start, String end){
        long rowID = -1;

        ContentValues newClass = new ContentValues();
        newClass.put("id", id);
        newClass.put("name", name);
        newClass.put("course", course);
        newClass.put("start", start);
        newClass.put("end", end);

        if(open()!=null){
            rowID = database.update("classes", newClass, "_id=" + _id, null);
            close();
        }
        return rowID;
    }

    public Cursor getAllClasses(){
        Cursor cursor = null;
        if(open() != null){
            Log.d("testing", "In getAllClasses");
            cursor = database.rawQuery("SELECT * FROM classes", null);
        }
        return cursor;
    }

    public Cursor getOneClass(long id){
        Cursor cursor = null;
        if(open() != null){
            Log.d("testing", "In getoneclass");
            cursor = database.rawQuery("SELECT * FROM classes WHERE _id=" +id, null);
        }
        return cursor;
    }

    public void deleteOneClass(long id) {
        long rowID = -1;
        if (open() != null) {
            Log.d("testing", "In getoneclass");
            //cursor = database.rawQuery("DELETE FROM classes WHERE _id=" +id, null);
            rowID = database.delete("classes", "_id=" + id, null);
            close();
        }
    }

    @Override
    public void onCreate(SQLiteDatabase db){
        Log.d("testing", "in onCreate dbhelper");
        String createQuery = "CREATE TABLE classes" +
                "(_id integer primary key autoincrement," +
                "name TEXT, course TEXT, id TEXT, start TEXT, end TEXT);";
        db.execSQL(createQuery);
        //insertClass("testID", "testName", "testCourse", "testStart", "testEnd");
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion){

    }
}
