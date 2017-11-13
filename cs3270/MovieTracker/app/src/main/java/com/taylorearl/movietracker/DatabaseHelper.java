package com.taylorearl.movietracker;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

/**
 * Created by taylor on 11/9/17.
 */

public class DatabaseHelper extends SQLiteOpenHelper{
    private SQLiteDatabase database;

    public DatabaseHelper(Context context, String name, SQLiteDatabase.CursorFactory factory, int version){
        super(context, name, factory,version);
    }

    //MOVIE
    //_id
    //title
    //date
    //genre
    //runtime
    //tagline
    //rating
    //poster
    //releaseDate


    public SQLiteDatabase open(){
        database = getWritableDatabase();
        return database;
    }

    public void close(){
        if(database != null){
            database.close();
        }
    }

    public long insertMovie(String title, String date, String genre,
                            String runtime, String tagline, String rating, String poster, String releaseDate){
        long rowID = -1;

        ContentValues newMovie = new ContentValues();
        newMovie.put("title", title);
        newMovie.put("date", date);
        newMovie.put("genre", genre);
        newMovie.put("runtime", runtime);
        newMovie.put("tagline", tagline);
        newMovie.put("rating", rating);
        newMovie.put("poster", poster);
        newMovie.put("releaseDate", releaseDate);

        if(open()!=null){
            rowID = database.insert("movies", null, newMovie);
            close();
        }
        return rowID;
    }

    public long updateMovie(long _id, String title, String date, String genre,
                            String runtime, String tagline, String rating, String poster, String releaseDate){
        long rowID = -1;

        ContentValues newMovie = new ContentValues();
        newMovie.put("title", title);
        newMovie.put("date", date);
        newMovie.put("genre", genre);
        newMovie.put("runtime", runtime);
        newMovie.put("tagline", tagline);
        newMovie.put("rating", rating);
        newMovie.put("poster", poster);
        newMovie.put("releaseDate", releaseDate);

        if(open()!=null){
            rowID = database.update("movies", newMovie, "_id=" + _id, null);
            close();
        }
        return rowID;
    }

    public Cursor getAllMovies(){
        Cursor cursor = null;
        if(open() != null){
            Log.d("testing", "In getAllMovies");
            cursor = database.rawQuery("SELECT * FROM movies", null);
        }
        return cursor;
    }

    public Cursor getOneMovie(long id){
        Cursor cursor = null;
        if(open() != null){
            Log.d("testing", "In getOneMovie");
            cursor = database.rawQuery("SELECT * FROM movies WHERE _id=" +id, null);
        }
        return cursor;
    }

    public void deleteOneMovie(long id) {
        long rowID = -1;
        if (open() != null) {
            Log.d("testing", "In deleteOneMovie");
            //cursor = database.rawQuery("DELETE FROM classes WHERE _id=" +id, null);
            rowID = database.delete("movies", "_id=" + id, null);
            close();
        }
    }

    public Cursor getMovieID(long id){
        Cursor cursor = null;
        if(open() != null){
            Log.d("testing", "In getMovieID");
            cursor = database.rawQuery("SELECT * FROM movies WHERE _id=" +id, null);
        }
        return cursor;
    }

    public void dropMovies(){
        if(open() != null){
            String createQuery = "CREATE TABLE movies" +
                    "(_id integer primary key autoincrement," +
                    "title TEXT, date TEXT, genre TEXT, runtime TEXT, tagline TEXT, rating TEXT, poster TEXT, releaseDate TEXT);";
            String dropQuery = "DROP TABLE movies";
            database.execSQL(dropQuery);
            database.execSQL(createQuery);
            close();
        }
    }

    @Override
    public void onCreate(SQLiteDatabase db){
        Log.d("testing", "in onCreate dbhelper");
        String createQuery = "CREATE TABLE movies" +
                "(_id integer primary key autoincrement," +
                "title TEXT, date TEXT, genre TEXT, runtime TEXT, tagline TEXT, rating TEXT, poster TEXT, releaseDate TEXT);";
        db.execSQL(createQuery);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion){

    }
}
